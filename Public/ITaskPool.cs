namespace FedoraDev.NPCSchedule
{
    public interface ITaskPool
    {
        void AddTask(ITaskPoolItem taskPoolItem);
        ITaskPoolItem FindTask(ITimeFrame timeFrame, IContext context);
    }
}
