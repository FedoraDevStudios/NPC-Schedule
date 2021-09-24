using System;

namespace FedoraDev.NPCSchedule
{
    public interface ITimeFrame : IComparable<ITimeFrame>
    {
        ITimeSolver StartTime { get; }
        ITimeSolver EndTime { get; }

        void SetTimeFrame(ITimeSolver startTime, ITimeSolver endTime);
        void SetTimeFrame(ITimeSolver startTime, ulong duration);
        void SetTimeFrame(ulong duration, ITimeSolver endTime);
        bool IsValidTime(ITimeSolver timeSolver);
        bool IsValidTime(ulong timeValue);
    }
}
