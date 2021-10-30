namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		void AddScheduleable(IScheduleable scheduleable);
		void SetTaskPool(ITaskPool taskPool);
	}
}
