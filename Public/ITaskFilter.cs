namespace FedoraDev.NPCSchedule
{
    public interface ITaskFilter
    {
        bool IsValid(IContext context);
    }
}
