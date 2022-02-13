using System.Linq;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public enum Operation
	{
		And,
		Or
	}

	public class ManyTaskFilter : ITaskFilter
	{
		[SerializeField] Operation _filterOperation = Operation.And;
		[SerializeField] ITaskFilter[] _taskFilters = new ITaskFilter[0];

		public ITaskFilter Produce(IScheduleFactory scheduleFactory) => new ManyTaskFilter();
		public bool IsValid(IContext context)
		{
			switch (_filterOperation)
			{
				case Operation.And:
					return _taskFilters.All(taskFilter => taskFilter.IsValid(context));

				case Operation.Or:
					return _taskFilters.Any(taskFilter => taskFilter.IsValid(context));
			}

			Debug.LogError("If you are seeing this, the ManyTaskFilter is operating with an unknown Operation type.");
			return false;
		}
	}
}
