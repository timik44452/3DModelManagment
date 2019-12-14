namespace ServiceAPI.Timers
{
    public interface ITimerTask
    {
        int Interval { get; set; }
        bool Looped { get; set; }

        bool CanRun();
        void Run();
    }
}
