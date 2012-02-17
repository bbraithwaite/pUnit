
namespace pUnit
{
    public interface IStopWatch
    {
        IStopWatch StartNew();
        void Stop();
        long ElapsedMilliseconds { get; }
    }
}
