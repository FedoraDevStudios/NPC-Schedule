namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		void AddScheduleable(IScheduleable scheduleable);
		void FillSchedule();
		void SetTaskPool(ITaskPool taskPool);
	}
}
