namespace FedoraDev.NPCSchedule
{
    public interface ITaskPoolItem
    {
        ITask Task { get; }
        ITimeFrame TimeFrame { get; }
        ITaskFilter TaskFilter { get; }
        IPrioritySolver PrioritySolver { get; }
        IAttendantSolver AttendantSolver { get; }
        bool StartFlexible { get; }
        bool EndFlexible { get; }

        ITaskPoolItem Produce(IScheduleFactory scheduleFactory);
    }
}
