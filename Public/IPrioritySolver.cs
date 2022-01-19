namespace FedoraDev.NPCSchedule
{
    public interface IPrioritySolver
    {
        int GetPriority(IContext context);
        IPrioritySolver Produce();
    }
}
