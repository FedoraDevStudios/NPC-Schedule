namespace FedoraDev.NPCSchedule
{
	public interface IScheduleFactory
    {
        ISchedule ProduceSchedule();
        ITaskPool ProduceTaskPool();
        ITaskPoolItem ProduceTaskPoolItem();
        IScheduleable ProduceScheduleable();
        ITimeFrame ProduceTimeFrame();
        ITimeSolver ProduceTimeSolver();
        IPrioritySolver ProducePrioritySolver();
        ITaskFilter ProduceTaskFilter();
        IAttendantSolver ProduceAttendantSolver();
        IContext ProduceContext();
    }
}
