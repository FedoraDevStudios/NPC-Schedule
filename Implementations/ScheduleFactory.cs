using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ScheduleFactory : SerializedScriptableObject, IScheduleFactory
	{
		[SerializeField] ISchedule _scheduleFab;
		[SerializeField] ITaskPool _taskPoolFab;
        [SerializeField] ITaskPoolItem _taskPoolItemFab;
		[SerializeField] IScheduleable _scheduleableFab;
        [SerializeField] ITimeFrame _timeFrameFab;
        [SerializeField] ITimeSolver _timeSolverFab;
        [SerializeField] IPrioritySolver _prioritySolverFab;
        [SerializeField] ITaskFilter _taskFilterFab;
        [SerializeField] IAttendantSolver _attendantSolverFab;
		[SerializeField] IContext _contextSolverFab;

		private void Reset()
		{
			if (_scheduleFab == null) _scheduleFab = new SimpleSchedule();
			if (_taskPoolFab == null) _taskPoolFab = new SimpleTaskPool();
			if (_taskPoolItemFab == null) _taskPoolItemFab = new SimpleTaskPoolItem();
			if (_scheduleableFab == null) _scheduleableFab = new SimpleScheduleable();
			if (_timeFrameFab == null) _timeFrameFab = new SimpleTimeFrame(_timeSolverFab, _timeSolverFab);
			if (_timeSolverFab == null) _timeSolverFab = new SimpleTimeSolver();
			if (_prioritySolverFab == null) _prioritySolverFab = new SimplePrioritySolver();
			if (_taskFilterFab == null) _taskFilterFab = new ManyTaskFilter();
			if (_attendantSolverFab == null) _attendantSolverFab = new SimpleAttendantSolver();
			if (_contextSolverFab == null) _contextSolverFab = new EmptyContext();
		}

		public ISchedule ProduceSchedule() => _scheduleFab.Produce(this);
		public ITaskPool ProduceTaskPool() => _taskPoolFab.Produce(this);
		public ITaskPoolItem ProduceTaskPoolItem() => _taskPoolItemFab.Produce(this);
		public IScheduleable ProduceScheduleable() => _scheduleableFab.Produce(this);
		public ITimeFrame ProduceTimeFrame() => _timeFrameFab.Produce(this);
		public ITimeSolver ProduceTimeSolver() => _timeSolverFab.Produce(this);
		public IPrioritySolver ProducePrioritySolver() => _prioritySolverFab.Produce(this);
		public ITaskFilter ProduceTaskFilter() => _taskFilterFab.Produce(this);
		public IAttendantSolver ProduceAttendantSolver() => _attendantSolverFab.Produce(this);
		public IContext ProduceContext() => _contextSolverFab.Produce(this);
	}
}
