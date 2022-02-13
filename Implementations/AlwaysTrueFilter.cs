namespace FedoraDev.NPCSchedule.Implementations
{
	public class AlwaysTrueFilter : ITaskFilter
	{
		public bool IsValid(IContext context) => true;
		public ITaskFilter Produce(IScheduleFactory scheduleFactory) => new AlwaysTrueFilter();
	}
}
