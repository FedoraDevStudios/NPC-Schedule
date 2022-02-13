namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		ISchedule Produce();
		void FillSchedule();
		void SetTaskPool(ITaskPool taskPool);
	}
}
