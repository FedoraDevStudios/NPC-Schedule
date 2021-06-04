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
			return _schedule[GetTaskIndexAt(value)].Task;
		}

		public ISchedule GetRuntime()
		{
			ListSchedule schedule = new ListSchedule();
			schedule._schedule = new List<IScheduleable>();
			for (int i = 0; i < _schedule.Count; i++)
				schedule._schedule.Add(_schedule[i]);

			return schedule;
		}

		public void AddTask(IScheduleable scheduleable)
		{
			_schedule.Add(scheduleable);
			SortSchedule();
		}

		public void ReplaceTaskAt(IScheduleable scheduleable, float timeValue)
		{
			int index = GetTaskIndexAt(timeValue);
			_schedule[index] = scheduleable;
		}

		int GetTaskIndexAt(float timeValue)
		{
			SortSchedule();

			for (int i = 1; i < _schedule.Count; i++)
				if (_schedule[i].TimeSolver.GetValue() > timeValue)
					return i - 1;

			return _schedule.Count - 1;
		}

		[Button("Sort")]
		private void SortSchedule() => _schedule.Sort();
	}
}
