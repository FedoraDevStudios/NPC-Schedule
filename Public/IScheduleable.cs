using System;

namespace FedoraDev.NPCSchedule
{
    public interface IScheduleable : IComparable<IScheduleable>
    {
        IScheduleable Produce(IScheduleFactory scheduleFactory);
        ITask Task { get; }
        ITimeFrame TimeFrame { get; }
    }
}
