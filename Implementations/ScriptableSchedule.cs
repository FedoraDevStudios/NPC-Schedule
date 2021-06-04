using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	[CreateAssetMenu(fileName = "New Schedule", menuName = "NPC/Schedule")]
	[HideMonoScript]
	public class ScriptableSchedule : SerializedScriptableObject, ISchedule
	{
		[SerializeField] ISchedule _schedule;

		public ITask GetCurrentTask(float value) => _schedule.GetCurrentTask(value);
		public void AddTask(IScheduleable scheduleable) => _schedule.AddTask(scheduleable);
		public void ReplaceTaskAt(IScheduleable scheduleable, float timeValue) => _schedule.ReplaceTaskAt(scheduleable, timeValue);
		public ISchedule GetRuntime() => _schedule.GetRuntime();
	}
}

