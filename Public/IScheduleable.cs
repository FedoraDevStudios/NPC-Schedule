using System;
using UnityEngine;

namespace FedoraDev.NPCSchedule
{
    public interface IScheduleable : IComparable<IScheduleable>
    {
        ITask Task { get; }
        ITimeSolver TimeSolver { get; }
    }
}
