using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTimeFrame : ITimeFrame
	{
		public ITimeSolver StartTime => _startTime;
		public ITimeSolver EndTime => _endTime;

		[SerializeField] ITimeSolver _startTime;
		[SerializeField] ITimeSolver _endTime;

		public SimpleTimeFrame(ITimeSolver startTime, ITimeSolver endTime)
		{
			_startTime = startTime;
			_endTime = endTime;
		}

		public ITimeFrame Produce()
		{
			ITimeSolver startTime = ScheduleFactory.ProduceTimeSolver();
			ITimeSolver endTime = ScheduleFactory.ProduceTimeSolver();
			startTime.SetTime(startTime.GetValue());
			endTime.SetTime(endTime.GetValue());
			SimpleTimeFrame timeFrame = new SimpleTimeFrame(startTime, endTime);
			return timeFrame;
		}

		public void SetTimeFrame(ulong startTime, ulong endTime)
		{
			_startTime.SetTime(startTime);
			_endTime.SetTime(endTime);
		}

		public bool IsValidTime(ITimeSolver timeSolver) => IsValidTime(timeSolver.GetValue());
		public bool IsValidTime(ulong timeValue) => _startTime.GetValue() < timeValue && timeValue < _endTime.GetValue();
		public int CompareTo(ITimeFrame other) => TimeFrameHelper.CompareTo(this, other);
	}
}
