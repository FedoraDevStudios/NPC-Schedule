using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
    public class LocaleBehaviour : MonoBehaviour, ILocale
    {
		public Vector3 TargetPosition => transform.position;

		public ILocale Produce(IScheduleFactory scheduleFactory) => Instantiate(this);
	}
}
