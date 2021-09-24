namespace FedoraDev.NPCSchedule
{
    public static class TimeFrameHelper
    {
		public static int CompareTo(ITimeFrame timeFrameA, ITimeFrame timeFrameB)
		{
			if (timeFrameB == null)
				return 1;

			ulong myValue = timeFrameA.StartTime.GetValue();
			ulong otherValue = timeFrameB.StartTime.GetValue();

			int comparison = myValue.CompareTo(otherValue);

			if (comparison != 0)
				return comparison;

			myValue = timeFrameA.EndTime.GetValue();
			otherValue = timeFrameB.EndTime.GetValue();

			return otherValue.CompareTo(myValue);
		}

        public static int CompareToPreferLaterEndTime(ITimeFrame timeFrameA, ITimeFrame timeFrameB)
		{
			if (timeFrameB == null)
				return 1;

			ulong myValue = timeFrameA.StartTime.GetValue();
			ulong otherValue = timeFrameB.StartTime.GetValue();

			int comparison = myValue.CompareTo(otherValue);

			if (comparison != 0)
				return comparison;

			myValue = timeFrameA.EndTime.GetValue();
			otherValue = timeFrameB.EndTime.GetValue();

			return myValue.CompareTo(otherValue);
		}
    }
}
