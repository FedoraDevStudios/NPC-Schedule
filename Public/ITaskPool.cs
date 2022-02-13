namespace FedoraDev.NPCSchedule
{
    public interface ITaskPool
    {
        ITaskPool Produce(IScheduleFactory scheduleFactory);
        void AddTask(ITaskPoolItem taskPoolItem);
        ITaskPoolItem FindTask(ITimeFrame timeFrame, IContext context);
    }
}
