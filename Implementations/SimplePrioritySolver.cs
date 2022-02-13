using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimplePrioritySolver : IPrioritySolver
	{
		[SerializeField] int _priority;

		public int GetPriority(IContext context) => _priority;
		public IPrioritySolver Produce(IScheduleFactory scheduleFactory) => new SimplePrioritySolver();
	}
}
