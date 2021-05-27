namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
        ITask GetCurrentTask();
        ITask GetNextTask();
    }
}
