using System;

namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
        ITask GetCurrentTask();
        ISchedule GetRuntime();
    }
}
