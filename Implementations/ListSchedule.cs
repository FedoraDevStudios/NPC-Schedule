using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ListSchedule : ISchedule
	{
		[SerializeField, HideLabel, BoxGroup("Schedule")] List<IScheduleable> _schedule = new List<IScheduleable>();

		public ITask GetCurrentTask() => throw new System.NotImplementedException();

		[Button("Sort")]
		private void SortList() => _schedule.Sort();
	}
}
