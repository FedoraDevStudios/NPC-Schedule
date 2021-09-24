using System;

namespace FedoraDev.NPCSchedule
{
    public interface IScheduleable : IComparable<IScheduleable>
    {
        ITask Task { get; }
        ITimeFrame TimeFrame { get; }
    }
}
