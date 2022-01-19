using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleAttendantSolver : IAttendantSolver
	{
		public IAttend[] Attendants { get => _attendants.ToArray(); }

		[SerializeField] List<IAttend> _attendants = new List<IAttend>();
		[SerializeField] int _minAttendants = 1;
		[SerializeField] int _maxAttendants = 1;

		public int GetMinAttendants(IContext context) => _minAttendants;
		public int GetMaxAttendants(IContext context) => _maxAttendants;

		public void AddAttendant(IAttend attendant) => _attendants.Add(attendant);
		public IAttendantSolver Produce() => new SimpleAttendantSolver();
	}
}
