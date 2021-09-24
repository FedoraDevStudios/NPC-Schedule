using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleAttendantSolver : IAttendantSolver
	{
		[SerializeField] int _minAttendants = 1;
		[SerializeField] int _maxAttendants = 1;

		public int GetMinAttendants(IContext context) => _minAttendants;
		public int GetMaxAttendants(IContext context) => _maxAttendants;
	}
}
