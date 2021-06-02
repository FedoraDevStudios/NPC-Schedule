using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class ListSchedule : ISchedule
	{
		[SerializeField, HideLabel, BoxGroup("Schedule")] List<IScheduleable> _schedule = new List<IScheduleable>();

		public ITask GetCurrentTask(float value)
		{
			SortSchedule();

			for (int i = 1; i < _schedule.Count; i++)
				if (_schedule[i].TimeSolver.GetValue() > value)
					return _schedule[i - 1].Task;

			return _schedule[_schedule.Count - 1].Task;
		}

		public ISchedule GetRuntime()
		{
			ListSchedule schedule = new ListSchedule();
			schedule._schedule = new List<IScheduleable>();
			for (int i = 0; i < _schedule.Count; i++)
				schedule._schedule.Add(_schedule[i]);

			return schedule;
		}

		[Button("Sort")]
		private void SortSchedule() => _schedule.Sort();
	}
}
