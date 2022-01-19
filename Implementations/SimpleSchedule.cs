using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleSchedule : ISchedule
	{
		[SerializeField, HideLabel, BoxGroup("Schedule")] List<IScheduleable> _schedule = new List<IScheduleable>();
		[SerializeField] ITaskPool _taskPool;
		[SerializeField] IScheduleable _defaultTask;

		public void AddScheduleable(IScheduleable scheduleable)
		{
			PruneTimeFrame(scheduleable.TimeFrame);
			AddToScheduleList(scheduleable);
			FillSchedule();
		}

		public void SetTaskPool(ITaskPool taskPool) => _taskPool = taskPool;

		public void FillSchedule()
		{
			//ITimeFrame timeFrame = GetNextHoleInSchedule();
			//for (int i = 100; i > 0; i--) //Do this up to 100 times before quitting.
			//{
			//	FillScheduleTimeFrame(timeFrame);

			//	timeFrame = GetNextHoleInSchedule();

			//	if (timeFrame == null)
			//		break;
			//}
		}

		[Button]
		public void AddTask()
		{
			if (!Application.isPlaying)
			{
				Debug.Log("Only fill the schedule in play mode.");
				return;
			}

			ITimeFrame timeFrame = GetNextHoleInSchedule();
			if (timeFrame == null)
			{
				Debug.Log("No space left in schedule.");
				return;
			}

			FillScheduleTimeFrame(timeFrame);
		}

		void FillScheduleTimeFrame(ITimeFrame timeFrame) //TODO: Add factory method
		{
			ITaskPoolItem taskPoolItem = _taskPool.FindTask(timeFrame);

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

				scheduleable.TimeFrame = ScheduleFactory.ProduceTimeFrame();
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
			if (_schedule.Count == 0)
				return new SimpleTimeFrame(_defaultTask.TimeFrame.StartTime, _defaultTask.TimeFrame.EndTime);

			if (_schedule.Count == 1)
			{
				if (_schedule[_schedule.Count - 1].TimeFrame.EndTime.GetValue() == _defaultTask.TimeFrame.EndTime.GetValue())
					return null;
				else
					return new SimpleTimeFrame(_schedule[0].TimeFrame.EndTime, _defaultTask.TimeFrame.EndTime);
			}

			for (int i = 1; i < _schedule.Count; i++)
				if (_schedule[i - 1].TimeFrame.EndTime.GetValue() != _schedule[i].TimeFrame.StartTime.GetValue())
					return new SimpleTimeFrame(_schedule[i - 1].TimeFrame.EndTime, _schedule[i].TimeFrame.StartTime);

			if (_schedule[_schedule.Count - 1].TimeFrame.EndTime.GetValue() == _defaultTask.TimeFrame.EndTime.GetValue())
				return null;

			return new SimpleTimeFrame(_schedule[_schedule.Count - 1].TimeFrame.EndTime, _defaultTask.TimeFrame.EndTime);
		}
	}
}
