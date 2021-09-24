using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTimeFrame : ITimeFrame
	{
		public ITimeSolver StartTime => _startTime;
		public ITimeSolver EndTime => _endTime;

		[SerializeField] ITimeSolver _startTime;
		[SerializeField] ITimeSolver _endTime;

		public SimpleTimeFrame(ITimeSolver startTime, ITimeSolver endTime) => SetTimeFrame(startTime, endTime);
		public SimpleTimeFrame(ITimeSolver startTime, ulong duration) => SetTimeFrame(startTime, duration);
		public SimpleTimeFrame(ulong duration, ITimeSolver endTime) => SetTimeFrame(duration, endTime);

		public void SetTimeFrame(ITimeSolver startTime, ITimeSolver endTime)
		{
			_startTime = startTime;
			_endTime = endTime;
		}

		public void SetTimeFrame(ITimeSolver startTime, ulong duration)
		{
			_startTime = startTime;
			startTime.AddTime(duration);
			_endTime = startTime;
		}

		public void SetTimeFrame(ulong duration, ITimeSolver endTime)
		{
			_endTime = endTime;
			endTime.SubtractTime(duration);
			_startTime = endTime;
		}

		public bool IsValidTime(ITimeSolver timeSolver) => IsValidTime(timeSolver.GetValue());
		public bool IsValidTime(ulong timeValue) => _startTime.GetValue() < timeValue && timeValue < _endTime.GetValue();
		public int CompareTo(ITimeFrame other) => TimeFrameHelper.CompareTo(this, other);
	}
}
