using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleLocale : ILocale
	{
		public Vector3 TargetPosition => _targetPosition;

		[SerializeField] Vector3 _targetPosition;

		public ILocale Produce(IScheduleFactory scheduleFactory) => new SimpleLocale();
	}
}
