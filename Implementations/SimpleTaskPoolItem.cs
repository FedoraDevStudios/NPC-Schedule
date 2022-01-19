using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTaskPoolItem : ITaskPoolItem
	{
		public ITask Task { get => _task; }
		public ITimeFrame TimeFrame { get => _timeFrame; }
		public IPrioritySolver PrioritySolver { get => _prioritySolver; }
		public ITaskFilter TaskFilter { get => _taskFilter; }
		public IAttendantSolver AttendantSolver { get => _attendantSolver; }
		public bool StartFlexible { get => _startFlexible; }
		public bool EndFlexible { get => _endFlexible; }

		[SerializeField] ITask _task;
		[SerializeField] ITimeFrame _timeFrame;
		[SerializeField] IPrioritySolver _prioritySolver;
		[SerializeField] ITaskFilter _taskFilter;
		[SerializeField] IAttendantSolver _attendantSolver;
		[SerializeField] bool _startFlexible = false;
		[SerializeField] bool _endFlexible = false;

		public SimpleTaskPoolItem() => Produce();

		public ITaskPoolItem Produce()
		{
			SimpleTaskPoolItem taskPoolItem = new SimpleTaskPoolItem();

			taskPoolItem._task = _task;
			taskPoolItem._timeFrame = ScheduleFactory.ProduceTimeFrame();
			taskPoolItem._prioritySolver = ScheduleFactory.ProducePrioritySolver();
			taskPoolItem._taskFilter = ScheduleFactory.ProduceTaskFilter();
			taskPoolItem._attendantSolver = ScheduleFactory.ProduceAttendantSolver();
			taskPoolItem._startFlexible = _startFlexible;
			taskPoolItem._endFlexible = _endFlexible;

			return taskPoolItem;
		}
	}
}
