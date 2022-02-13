namespace FedoraDev.NPCSchedule
{
    public interface ITaskPool
    {
        ITaskPool Produce();
        void AddTask(ITaskPoolItem taskPoolItem);
        ITaskPoolItem FindTask(ITimeFrame timeFrame, IContext context);
    }
}
