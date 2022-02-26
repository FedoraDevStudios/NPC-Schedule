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
                _schedule = ScheduleFactoryBehaviour.ScheduleFactory.ProduceSchedule();
        }

        void Reset()
		{
            if (_schedule == null)
                _schedule = ScheduleFactoryBehaviour.ScheduleFactory.ProduceSchedule();
		}

		public ISchedule Produce(IScheduleFactory scheduleFactory) => _schedule.Produce(scheduleFactory);
		public void FillSchedule() => _schedule.FillSchedule();
		public void SetTaskPool(ITaskPool taskPool) => _schedule.SetTaskPool(taskPool);
        public IScheduleable GetTaskAt(ITimeSolver time) => _schedule.GetTaskAt(time);
	}
}
