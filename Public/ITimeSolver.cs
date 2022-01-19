namespace FedoraDev.NPCSchedule
{
    public interface ITimeSolver
    {
        ulong GetValue();

        void SetTime(ulong value);
        void AddTime(ulong duration);
        void SubtractTime(ulong duration);

        ITimeSolver Produce();
    }
}
