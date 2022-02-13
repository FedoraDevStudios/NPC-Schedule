using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ScheduleFactory : SerializedScriptableObject
    {
        [SerializeField] ITaskPoolItem _taskPoolItemFab;
        [SerializeField] ITimeFrame _timeFrameFab;
        [SerializeField] ITimeSolver _timeSolverFab;
        [SerializeField] IPrioritySolver _prioritySolverFab;
        [SerializeField] ITaskFilter _taskFilterFab;
        [SerializeField] IAttendantSolver _attendantSolverFab;
		[SerializeField] IContext _contextSolverFab;

		private void Reset()
		{
			if (_timeSolverFab == null)
				_timeSolverFab = new SimpleTimeSolver();

			if (_timeFrameFab == null)
				_timeFrameFab = new SimpleTimeFrame(_timeSolverFab, _timeSolverFab);

			if (_taskPoolItemFab == null)
				_taskPoolItemFab = new SimpleTaskPoolItem();

			if (_prioritySolverFab == null)
				_prioritySolverFab = new SimplePrioritySolver();

			if (_taskFilterFab == null)
				_taskFilterFab = new ManyTaskFilter();

			if (_attendantSolverFab == null)
				_attendantSolverFab = new SimpleAttendantSolver();

			if (_contextSolverFab == null)
				_contextSolverFab = new EmptyContext();
		}

		public static ITaskPoolItem ProduceTaskPoolItem()
		{
            return ScheduleFactoryBehaviour.ScheduleFactory._taskPoolItemFab.Produce();
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
