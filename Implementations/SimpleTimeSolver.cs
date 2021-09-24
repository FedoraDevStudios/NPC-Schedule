using System;
using System.Collections.Generic;
using UnityEngine;

namespace FedoraDev.NPCSchedule.Implementations
{
	public class SimpleTimeSolver : ITimeSolver
	{
		[SerializeField] byte _daysPerMonth = 28;
		[SerializeField] byte _minute;
		[SerializeField] byte _hour;
		[SerializeField] byte _day;
		[SerializeField] byte _month;
		[SerializeField] ushort _year;

		public ulong GetValue()
		{
			List<byte> bytes = new List<byte>(8);
			bytes.AddRange(BitConverter.GetBytes(_minute));
			bytes.AddRange(BitConverter.GetBytes(_hour));
			bytes.AddRange(BitConverter.GetBytes(_day));
			bytes.AddRange(BitConverter.GetBytes(_month));
			bytes.AddRange(BitConverter.GetBytes(_year));

			return BitConverter.ToUInt64(bytes.ToArray(), 0);
		}

		public void AddTime(ulong duration)
		{
			byte[] bytes = BitConverter.GetBytes(duration);
			byte minute = bytes[0];
			byte hour = bytes[1];
			byte day = bytes[2];
			byte month = bytes[3];
			ushort year = BitConverter.ToUInt16(bytes, 4);

			_minute += minute;
			_hour += hour;
			_day += day;
			_month += month;
			_year += year;

			while (_minute >= 60)
			{
				_minute -= 60;
				_hour++;
			}

			while (_hour >= 24)
			{
				_hour -= 24;
				_day++;
			}

			while (_day >= _daysPerMonth)
			{
				_day -= _daysPerMonth;
				_month++;
			}

			while (_month >= 4)
			{
				_month -= 4;
				_year++;
			}
		}

		public void SubtractTime(ulong duration)
		{
			byte[] bytes = BitConverter.GetBytes(duration);
			byte minute = bytes[0];
			byte hour = bytes[1];
			byte day = bytes[2];
			byte month = bytes[3];
			ushort year = BitConverter.ToUInt16(bytes, 4);

			while (minute > _minute)
			{
				minute -= 60;
				hour++;
			}

			while (hour > _hour)
			{
				hour -= 24;
				day++;
			}

			while (day > _day)
			{
				day -= _daysPerMonth;
				month++;
			}

			while (month > _month)
			{
				month -= 4;
				year++;
			}

			if (year > _year)
				Debug.LogError("Subtracted more time than this time solver has available!");

			_minute -= minute;
			_hour -= hour;
			_day -= day;
			_month -= month;
			_year -= year;
		}
	}
}
