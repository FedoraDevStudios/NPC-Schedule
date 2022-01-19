namespace FedoraDev.NPCSchedule
{
	public interface IScheduleFactory
    {
        ITaskPoolItem ProduceTaskPoolItem();
        ITimeFrame ProduceTimeFrame();
        ITimeSolver ProduceTimeSolver();
        IPrioritySolver ProducePrioritySolver();
        ITaskFilter ProduceTaskFilter();
        IAttendantSolver ProduceAttendantSolver();
    }
}
