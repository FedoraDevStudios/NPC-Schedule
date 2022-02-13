using System;

namespace FedoraDev.NPCSchedule
{
    public interface ITimeFrame : IComparable<ITimeFrame>
    {
        ITimeSolver StartTime { get; }
        ITimeSolver EndTime { get; }

        bool IsValidTime(ITimeSolver timeSolver);
        bool IsValidTime(ulong timeValue);

        ITimeFrame Produce(IScheduleFactory scheduleFactory);
    }
}
