using System;

namespace FedoraDev.NPCSchedule
{
    public interface IScheduleable : IComparable<IScheduleable>
    {
        IScheduleable Produce();
        ITask Task { get; }
        ITimeFrame TimeFrame { get; }
    }
}
