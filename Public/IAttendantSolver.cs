namespace FedoraDev.NPCSchedule
{
    public interface IAttendantSolver
    {
        IAttend[] Attendants { get; }

        IAttendantSolver Produce(IScheduleFactory scheduleFactory);
        int GetMinAttendants(IContext context);
        int GetMaxAttendants(IContext context);
        void AddAttendant(IAttend attendant);
    }
}
