using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Examples
{
    public class ScheduleBehaviour : SerializedMonoBehaviour
    {
        [SerializeField] ISchedule _schedule;

        void Start()
        {
            _schedule.FillSchedule();
        }
    }
}
