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

		public void FillSchedule()
		{
			ITimeFrame timeFrame = GetNextHoleInSchedule();
			while (timeFrame != null)
			{
				FillScheduleTimeFrame(timeFrame);

				timeFrame = GetNextHoleInSchedule();
			}
		}

		void FillScheduleTimeFrame(ITimeFrame timeFrame)
		{
			ITaskPoolItem taskPoolItem = _taskPool.FindTask(timeFrame);
			if (taskPoolItem == null)
			{
				IScheduleable fill = _defaultTask;
				fill.TimeFrame.SetTimeFrame(timeFrame.StartTime, timeFrame.EndTime);
				AddToScheduleList(fill);
			}
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
			for (int i = 1; i < _schedule.Count; i++)
				if (_schedule[i - 1].TimeFrame.EndTime != _schedule[i].TimeFrame.StartTime)
					return new SimpleTimeFrame(_schedule[i - 1].TimeFrame.EndTime, _schedule[i].TimeFrame.StartTime);

			return null;
		}
	}
}
