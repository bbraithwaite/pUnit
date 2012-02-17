using System;
using System.Diagnostics;

namespace pUnit
{
    public class NativeStopWatch : IStopWatch
    {
        private Stopwatch stopWatch;

        public void Stop()
        {
            this.stopWatch.Stop();
        }

        public long ElapsedMilliseconds
        {
            get { return stopWatch.ElapsedMilliseconds; }
        }

        IStopWatch IStopWatch.StartNew()
        {
            this.stopWatch = Stopwatch.StartNew();
            return this;
        }
    }
}