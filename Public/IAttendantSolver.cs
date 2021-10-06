namespace FedoraDev.NPCSchedule
{
    public interface IAttendantSolver
    {
        IAttend[] Attendants { get; }

        int GetMinAttendants(IContext context);
        int GetMaxAttendants(IContext context);
        void AddAttendant(IAttend attendant);
    }
}
