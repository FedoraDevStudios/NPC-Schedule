namespace FedoraDev.NPCSchedule
{
    public static class ScheduleableHelper
    {
        public static int CompareTo(IScheduleable scheduleableA, IScheduleable scheduleableB)
		{
            if (scheduleableB == null)
                return 1;
            return scheduleableA.TimeFrame.CompareTo(scheduleableB.TimeFrame);
        }
    }
}
