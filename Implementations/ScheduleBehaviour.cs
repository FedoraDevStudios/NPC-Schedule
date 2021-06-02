using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	[HideMonoScript]
    public class ScheduleBehaviour : SerializedMonoBehaviour
    {
        [SerializeField, InlineEditor, HideLabel, BoxGroup("Schedule")] ISchedule _schedule;

		private void Awake()
		{
			_schedule = _schedule.GetRuntime();
		}
	}
}
