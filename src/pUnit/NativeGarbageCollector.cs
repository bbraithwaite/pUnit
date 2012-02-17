using System;

namespace pUnit
{
    public class NativeGarbageCollector : IGarbageCollector
    {
        public void Collect()
        {
            GC.Collect();
        }

        public void WaitForPendingFinalizers()
        {
            GC.WaitForPendingFinalizers();
        }
    }
}
