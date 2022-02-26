namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		ISchedule Produce(IScheduleFactory scheduleFactory);
		void FillSchedule();
		void SetTaskPool(ITaskPool taskPool);
		IScheduleable GetTaskAt(ITimeSolver time);
	}
}
