namespace FedoraDev.NPCSchedule
{
    public interface IContext
    {
        IContext Produce(IScheduleFactory scheduleFactory);
    }
}
