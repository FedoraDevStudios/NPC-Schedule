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
			return null;
		}
	}
}
