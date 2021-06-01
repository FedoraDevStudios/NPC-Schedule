using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	[CreateAssetMenu(fileName = "New Schedule", menuName = "NPC/Schedule")]
	public class ScriptableSchedule : SerializedScriptableObject, ISchedule
	{
		[SerializeField] ISchedule _schedule;

		public ITask GetCurrentTask() => _schedule.GetCurrentTask();
		public ISchedule GetRuntime() => _schedule.GetRuntime();
	}
}
