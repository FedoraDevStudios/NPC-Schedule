using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ScheduleFactory : SerializedScriptableObject
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
			if (_scheduleFab == null)
				_scheduleFab = new SimpleSchedule();

			if (_taskPoolFab == null)
				_taskPoolFab = new SimpleTaskPool();

			if (_taskPoolItemFab == null)
				_taskPoolItemFab = new SimpleTaskPoolItem();

			if (_scheduleableFab == null)
				_scheduleableFab = new SimpleScheduleable();

			if (_timeFrameFab == null)
				_timeFrameFab = new SimpleTimeFrame(_timeSolverFab, _timeSolverFab);

			if (_timeSolverFab == null)
				_timeSolverFab = new SimpleTimeSolver();

			if (_prioritySolverFab == null)
				_prioritySolverFab = new SimplePrioritySolver();

			if (_taskFilterFab == null)
				_taskFilterFab = new ManyTaskFilter();

			if (_attendantSolverFab == null)
				_attendantSolverFab = new SimpleAttendantSolver();

			if (_contextSolverFab == null)
				_contextSolverFab = new EmptyContext();
		}

		public static ISchedule ProduceSchedule()
		{
			return ScheduleFactoryBehaviour.ScheduleFactory._scheduleFab.Produce();
		}

		public static ITaskPool ProduceTaskPool()
		{
			return ScheduleFactoryBehaviour.ScheduleFactory._taskPoolFab.Produce();
		}

		public static ITaskPoolItem ProduceTaskPoolItem()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._taskPoolItemFab.Produce();
		}

		public static IScheduleable ProduceScheduleable()
		{
			return ScheduleFactoryBehaviour.ScheduleFactory._scheduleableFab.Produce();
		}

        public static ITimeFrame ProduceTimeFrame()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._timeFrameFab.Produce();
		}

        public static ITimeSolver ProduceTimeSolver()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._timeSolverFab.Produce();
		}

        public static IPrioritySolver ProducePrioritySolver()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._prioritySolverFab.Produce();
		}

        public static ITaskFilter ProduceTaskFilter()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._taskFilterFab.Produce();
		}

        public static IAttendantSolver ProduceAttendantSolver()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._attendantSolverFab.Produce();
		}

		public static IContext ProduceContext()
		{
			return ScheduleFactoryBehaviour.ScheduleFactory._contextSolverFab.Produce();
		}
	}
}
