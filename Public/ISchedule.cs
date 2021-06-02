using System;

namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
        ITask GetCurrentTask(float value);
        ISchedule GetRuntime();
    }
}
