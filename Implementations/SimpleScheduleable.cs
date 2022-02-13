using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleScheduleable : IScheduleable
	{
		public ITask Task { get => _task; set => _task = value; }
		public ITimeFrame TimeFrame { get => _timeFrame; set => _timeFrame = value; }

		[SerializeField] ITask _task;
		[SerializeField] ITimeFrame _timeFrame;

		public IScheduleable Produce(IScheduleFactory scheduleFactory)
		{
			SimpleScheduleable scheduleable = new SimpleScheduleable();
			scheduleable._timeFrame = scheduleFactory.ProduceTimeFrame();
			return scheduleable;
		}

		public int CompareTo(IScheduleable scheduleable) => ScheduleableHelper.CompareTo(this, scheduleable);
	}
}
