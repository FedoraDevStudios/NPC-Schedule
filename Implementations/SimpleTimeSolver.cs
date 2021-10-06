using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTimeSolver : ITimeSolver
	{
		[SerializeField, HorizontalGroup("Time"), LabelText("Time")] byte _hour;
		[SerializeField, HorizontalGroup("Time"), LabelText(":"), LabelWidth(5f)] byte _minute;

		public ulong GetValue()
		{
			List<byte> bytes = new List<byte>(8);
			bytes.Add(_minute);
			bytes.Add(_hour);

			return BitConverter.ToUInt64(bytes.ToArray(), 0);
		}

		public void AddTime(ulong duration)
		{
			byte[] bytes = BitConverter.GetBytes(duration);
			byte minute = bytes[0];
			byte hour = bytes[1];
			byte oldMinute = _minute;
			byte oldHour = _hour;

			_minute += minute;
			_hour += hour;

			while (_minute >= 60)
			{
				_minute -= 60;
				_hour++;
			}

			if (_hour >= 24)
				Debug.LogError($"Time Overflow: Adding {hour}:{minute} to {oldHour}:{oldMinute} results in {_hour}:{_minute}");
		}

		public void SubtractTime(ulong duration)
		{
			byte[] bytes = BitConverter.GetBytes(duration);
			byte minute = bytes[0];
			byte hour = bytes[1];
			byte oldMinute = minute;
			byte oldHour = hour;

			while (minute > _minute)
			{
				minute -= 60;
				hour++;
			}

			if (hour > _hour)
			{
				Debug.LogError($"Time Underflow: Subtracting {oldHour}:{oldMinute} from {_hour}:{_minute} results in a negative value.");
				_minute = 0;
				_hour = 0;
				return;
			}

			_minute -= minute;
			_hour -= hour;
		}
	}
}
