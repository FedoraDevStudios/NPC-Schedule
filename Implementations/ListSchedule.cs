using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ListSchedule : ISchedule
	{
		[SerializeField, HideLabel, BoxGroup("Schedule")] List<IScheduleable> _schedule = new List<IScheduleable>();

		public ITask GetCurrentTask() => throw new System.NotImplementedException();

		public ISchedule GetRuntime()
		{
			ListSchedule schedule = new ListSchedule();
			schedule._schedule = new List<IScheduleable>();
			for (int i = 0; i < _schedule.Count; i++)
				schedule._schedule.Add(_schedule[i]);

			return schedule;
		}

		[Button("Sort")]
		private void SortList() => _schedule.Sort();
	}
}
