namespace FedoraDev.NPCSchedule.Implementations
{
    public class EmptyContext : IContext
    {
        public IContext Produce() => new EmptyContext();
    }
}
