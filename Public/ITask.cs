namespace FedoraDev.NPCSchedule
{
	public interface ITask
    {
        ITimeSolver MinimumDuration { get; }

        void DoTask(IContext context);
    }
}
