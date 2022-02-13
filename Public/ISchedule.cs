namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		void FillSchedule();
		void SetTaskPool(ITaskPool taskPool);
	}
}
