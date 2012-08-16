using System;
using System.Diagnostics;

namespace pUnit
{
    public class NativeStopWatch : IStopWatch
    {
        private Stopwatch _stopWatch;

        public void Stop()
        {
            this._stopWatch.Stop();
        }

        public long ElapsedMilliseconds
        {
            get { return _stopWatch.ElapsedMilliseconds; }
        }

        IStopWatch IStopWatch.StartNew()
        {
            this._stopWatch = Stopwatch.StartNew();
            return this;
        }
    }
}