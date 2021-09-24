using System.Linq;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ManyTaskFilter : ITaskFilter
	{
		[SerializeField] ITaskFilter[] _taskFilters = new ITaskFilter[0];

		public bool IsValid(IContext context) => _taskFilters.All(taskFilter => taskFilter.IsValid(context));
	}
}
