using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class TaskPoolBehaviour : SerializedMonoBehaviour, ITaskPool
	{
		[SerializeField] ITaskPool _taskPool;

		public ITaskPool Produce(IScheduleFactory scheduleFactory) => _taskPool.Produce(scheduleFactory);
		public void AddTask(ITaskPoolItem taskPoolItem) => _taskPool.AddTask(taskPoolItem);
		public ITaskPoolItem FindTask(ITimeFrame timeFrame, IContext context) => _taskPool.FindTask(timeFrame, context);
	}
}
