using UnityEngine;

namespace FedoraDev.NPCSchedule
{
    public interface ILocale
    {
        Vector3 TargetPosition { get; }

        ILocale Produce(IScheduleFactory scheduleFactory);
    }
}
