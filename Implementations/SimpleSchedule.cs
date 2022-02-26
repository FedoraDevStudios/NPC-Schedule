using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleSchedule : ISchedule
	{
		[SerializeField, HideLabel, BoxGroup("Schedule")] List<IScheduleable> _schedule = new List<IScheduleable>();
		[SerializeField] IContext _context;
		[SerializeField] ITaskPool _taskPool;
		[SerializeField] IScheduleable _defaultTask;
		[SerializeField] int _maxIterationsForSafety = 100;

		//TODO: Add a way to 'push' a task to an NPC and have them consider whether they want to attend.
		//public void AddScheduleable(IScheduleable scheduleable)
		//{
		//	PruneTimeFrame(scheduleable.TimeFrame);
		//	AddToScheduleList(scheduleable);
		//	FillSchedule();
		//}

		public ISchedule Produce(IScheduleFactory scheduleFactory)
		{
			SimpleSchedule schedule = new SimpleSchedule();
			schedule._context = scheduleFactory.ProduceContext();
			schedule._defaultTask = scheduleFactory.ProduceScheduleable();
			return schedule;
		}

		public void SetTaskPool(ITaskPool taskPool) => _taskPool = taskPool;

		public void FillSchedule()
		{
			ITimeFrame timeFrame = GetNextHoleInSchedule();
			for (int i = _maxIterationsForSafety; i > 0; i--) //Do this up to 100 times before quitting.
			{
				FillScheduleTimeFrame(timeFrame);

				timeFrame = GetNextHoleInSchedule();

				if (timeFrame == null)
					break;
			}
		}

		public IScheduleable GetTaskAt(ulong timeValue)
		{
			int taskIndex = GetTaskIndexAtTime(timeValue);
			if (taskIndex == -1)
				return null;
			return _schedule[taskIndex];
		}

		void FillScheduleTimeFrame(ITimeFrame timeFrame)
		{
			ITaskPoolItem taskPoolItem = _taskPool.FindTask(timeFrame, _context);

			if (taskPoolItem != null)
			{
				SimpleScheduleable scheduleable = new SimpleScheduleable();
				scheduleable.Task = taskPoolItem.Task;

				ulong taskStart = taskPoolItem.TimeFrame.StartTime.GetValue();
				ulong taskEnd = taskPoolItem.TimeFrame.EndTime.GetValue();
				ulong frameStart = timeFrame.StartTime.GetValue();
				ulong frameEnd = timeFrame.EndTime.GetValue();

				ulong startTime = taskPoolItem.StartFlexible && frameStart > taskStart ? frameStart : taskStart;
				ulong endTime = taskPoolItem.EndFlexible && frameEnd < taskEnd ? frameEnd : taskEnd;

				scheduleable.TimeFrame = ScheduleFactoryBehaviour.ScheduleFactory.ProduceTimeFrame();
				scheduleable.TimeFrame.StartTime.SetTime(startTime);
				scheduleable.TimeFrame.EndTime.SetTime(endTime);
				AddToScheduleList(scheduleable);
				return;
			}

			SimpleScheduleable defaultScheduleable = new SimpleScheduleable();
			defaultScheduleable.Task = _defaultTask.Task;
			defaultScheduleable.TimeFrame = new SimpleTimeFrame(timeFrame.StartTime, timeFrame.EndTime);
			AddToScheduleList(defaultScheduleable);
		}

		void AddToScheduleList(IScheduleable scheduleable)
		{
			_schedule.Add(scheduleable);
			_schedule.Sort();
		}

		void PruneTimeFrame(ITimeFrame timeFrame)
		{
			ulong startTime = timeFrame.StartTime.GetValue();
			ulong endTime = timeFrame.EndTime.GetValue();

			int startIndex = GetTaskIndexAtTime(startTime);
			int endIndex = GetTaskIndexAtTime(endTime);

			int[] indexesToRemove = Enumerable.Range(startIndex, endIndex - startIndex).ToArray();

			for (int i = 0; i < indexesToRemove.Length; i++)
				_schedule.RemoveAt(indexesToRemove[i]);
		}

		int GetTaskIndexAtTime(ulong time)
		{
			for (int i = 0; i < _schedule.Count; i++)
				if (_schedule[i].TimeFrame.IsValidTime(time))
					return i;

			return -1;
		}

		ITimeFrame GetNextHoleInSchedule()
		{
			ITimeFrame timeFrame = ScheduleFactoryBehaviour.ScheduleFactory.ProduceTimeFrame();

			if (_schedule.Count == 0)
			{
				timeFrame.StartTime.SetTime(_defaultTask.TimeFrame.StartTime.GetValue());
				timeFrame.EndTime.SetTime(_defaultTask.TimeFrame.EndTime.GetValue());
				return timeFrame;
			}

			bool startMatch = _schedule[0].TimeFrame.StartTime.GetValue() == _defaultTask.TimeFrame.StartTime.GetValue(); //Does the first task start at the first available start time?
			bool endMatch = _schedule[_schedule.Count - 1].TimeFrame.EndTime.GetValue() == _defaultTask.TimeFrame.EndTime.GetValue(); //Does the last task end at the last available end time?

			if (_schedule.Count == 1)
			{
				if (startMatch && endMatch)
					return null;
				else if (startMatch)
				{
					timeFrame.StartTime.SetTime(_schedule[_schedule.Count - 1].TimeFrame.EndTime.GetValue());
					timeFrame.EndTime.SetTime(_defaultTask.TimeFrame.EndTime.GetValue());
					return timeFrame;
				}
				else
				{
					timeFrame.StartTime.SetTime(_defaultTask.TimeFrame.StartTime.GetValue());
					timeFrame.EndTime.SetTime(_schedule[_schedule.Count - 1].TimeFrame.StartTime.GetValue());
					return timeFrame;
				}
			}

			if (!startMatch)
			{
				timeFrame.StartTime.SetTime(_defaultTask.TimeFrame.StartTime.GetValue());
				timeFrame.EndTime.SetTime(_schedule[0].TimeFrame.StartTime.GetValue());
				return timeFrame;
			}

			for (int i = 1; i < _schedule.Count; i++)
				if (_schedule[i - 1].TimeFrame.EndTime.GetValue() != _schedule[i].TimeFrame.StartTime.GetValue())
				{
					timeFrame.StartTime.SetTime(_schedule[i - 1].TimeFrame.EndTime.GetValue());
					timeFrame.EndTime.SetTime(_schedule[i].TimeFrame.StartTime.GetValue());
					return timeFrame;
				}

			if (endMatch)
				return null;

			timeFrame.StartTime.SetTime(_schedule[_schedule.Count - 1].TimeFrame.EndTime.GetValue());
			timeFrame.EndTime.SetTime(_defaultTask.TimeFrame.EndTime.GetValue());
			return timeFrame;
		}
	}
}
