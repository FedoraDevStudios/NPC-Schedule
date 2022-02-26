namespace FedoraDev.NPCSchedule
{
	public interface ITask
    {
        ITimeSolver MinimumDuration { get; }
        ILocale Locale { get; }

        void DoTask(IContext context);
    }
}
