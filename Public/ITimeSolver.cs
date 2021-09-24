namespace FedoraDev.NPCSchedule
{
    public interface ITimeSolver
    {
        ulong GetValue();

        void AddTime(ulong duration);
        void SubtractTime(ulong duration);
    }
}
