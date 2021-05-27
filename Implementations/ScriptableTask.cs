using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
    [CreateAssetMenu(fileName = "New Task", menuName = "NPC/Task")]
	public class ScriptableTask : SerializedScriptableObject, ITask
    {
        [SerializeField] ITask _task;
    }
}
