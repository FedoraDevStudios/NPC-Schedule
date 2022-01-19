using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTaskPool : ITaskPool
	{
		[SerializeField] List<ITaskPoolItem> _taskPool;

		public SimpleTaskPool()
		{
			if (_taskPool == null)
				_taskPool = new List<ITaskPoolItem>();
		}

		public void AddTask(ITaskPoolItem taskPoolItem)
		{
			_taskPool.Add(taskPoolItem);
		}

		public ITaskPoolItem FindTask(ITimeFrame timeFrame)
		{
			for (int i = 0; i < _taskPool.Count; i++)
			{
				ulong taskStart = _taskPool[i].TimeFrame.StartTime.GetValue();
				ulong taskEnd = _taskPool[i].TimeFrame.EndTime.GetValue();
				ulong frameStart = timeFrame.StartTime.GetValue();
				ulong frameEnd = timeFrame.EndTime.GetValue();

				bool startTimeMatch = _taskPool[i].StartFlexible ? taskEnd > frameStart : taskStart >= frameStart;
				bool endTimeMatch = _taskPool[i].EndFlexible ? taskStart < frameEnd : taskEnd <= frameEnd;

				if (startTimeMatch && endTimeMatch)
					return _taskPool[i];
			}

			return null;
		}
	}
}
