using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
    public class ScheduleBehaviour : SerializedMonoBehaviour, ISchedule
    {
        [SerializeField] ISchedule _schedule;

        void Start()
        {
            _schedule.FillSchedule();
        }

		private void OnValidate()
		{
            if (_schedule == null)
                _schedule = ScheduleFactory.ProduceSchedule();
        }

        void Reset()
		{
            if (_schedule == null)
                _schedule = ScheduleFactory.ProduceSchedule();
		}

		public ISchedule Produce() => _schedule.Produce();
		public void FillSchedule() => _schedule.FillSchedule();
		public void SetTaskPool(ITaskPool taskPool) => _schedule.SetTaskPool(taskPool);
	}
}
