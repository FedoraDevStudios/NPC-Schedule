using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
    [CreateAssetMenu(fileName = "New Task", menuName = "NPC/Task")]
    [HideMonoScript]
	public class ScriptableTask : SerializedScriptableObject, ITask
    {
        [SerializeField] ITask _task;
    }
}
