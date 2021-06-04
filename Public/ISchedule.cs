using System;

namespace FedoraDev.NPCSchedule
{
	public interface ISchedule
    {
		ITask GetCurrentTask(float value);
		void AddTask(IScheduleable scheduleable);
		void ReplaceTaskAt(IScheduleable scheduleable, float timeValue);
        ISchedule GetRuntime();
	}
}
