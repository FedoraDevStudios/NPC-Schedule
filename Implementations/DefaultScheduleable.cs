using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class DefaultScheduleable : IScheduleable
	{
		public ITask Task => _task;
		public ITimeSolver TimeSolver => _timeSolver;

		[SerializeField, InlineEditor, HideLabel, BoxGroup("Task")] ITask _task;
		[SerializeField, InlineEditor, HideLabel, BoxGroup("Time")] ITimeSolver _timeSolver;

		public int CompareTo(IScheduleable other) => TimeSolver.GetValue() < other.TimeSolver.GetValue() ? -1 : 1;
	}
}
