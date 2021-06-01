using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class DefaultTimeSolver : ITimeSolver
	{
		#region Editor Display
#if UNITY_EDITOR
		[SerializeField, DisplayAsString, HideLabel, HorizontalGroup("TimeName")] string _hourName = "Hour";
		[SerializeField, DisplayAsString, HideLabel, HorizontalGroup("TimeName")] string _minuteName = "Minute";
#endif
		#endregion

		[SerializeField, HorizontalGroup("Time"), HideLabel, Range(0, 24)] int _hour;
		[SerializeField, HorizontalGroup("Time"), HideLabel, Range(0, 59)] int _minute;

		public float GetValue() => _hour + (_minute / 100f);
	}
}
