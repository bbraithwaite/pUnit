
namespace pUnit
{
    public interface IGarbageCollector
    {
        void Collect();
        void WaitForPendingFinalizers();
    }
}
