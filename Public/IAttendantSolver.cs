namespace FedoraDev.NPCSchedule
{
    public interface IAttendantSolver
    {
        int GetMinAttendants(IContext context);
        int GetMaxAttendants(IContext context);
    }
}
