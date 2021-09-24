using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class TaskPoolBehaviour : SerializedMonoBehaviour, ITaskPool
	{
		[SerializeField] ITaskPool _taskPool;

		public void AddTask(ITaskPoolItem taskPoolItem) => _taskPool.AddTask(taskPoolItem);
		public ITaskPoolItem FindTask(ITimeFrame timeFrame) => _taskPool.FindTask(timeFrame);
	}
}
