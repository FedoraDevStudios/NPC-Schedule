namespace FedoraDev.NPCSchedule.Implementations
{
    public class EmptyContext : IContext
    {
        public IContext Produce(IScheduleFactory scheduleFactory) => new EmptyContext();
    }
}
