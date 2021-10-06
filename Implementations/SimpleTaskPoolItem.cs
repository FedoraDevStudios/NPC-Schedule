using Sirenix.OdinInspector;
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

		[SerializeField] ITask _task;
		[SerializeField] ITimeFrame _timeFrame;
		[SerializeField] IPrioritySolver _prioritySolver;
		[SerializeField] ITaskFilter _taskFilter;
		[SerializeField] IAttendantSolver _attendantSolver;
	}
}
