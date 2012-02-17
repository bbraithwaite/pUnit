using System;

namespace pUnit
{
    public class Profiler
    {
        private readonly IConsole _console;
        private readonly IGarbageCollector _garbageCollector;
        private readonly IStopWatch _stopWatch;

        public Profiler(IConsole console, IGarbageCollector garbageCollector, IStopWatch stopWatch)
        {
            _console = console;
            _garbageCollector = garbageCollector;
            _stopWatch = stopWatch;
        }
        /// <summary>
        /// Profiles the method in question
        /// </summary>
        /// <param name="description">the description of the test</param>
        /// <param name="iterations">the number of iterations to perform</param>
        /// <param name="func">the method to execute</param>
        /// <remarks>
        /// This method was taken from the following question at stackoverflow.com. 
        /// It was chosen due to the simplicity, which is the main principle of this program: http://stackoverflow.com/a/1048708
        /// </remarks>
        public void Profile(string description, int iterations, Action func)
        {
            // clean up
            _garbageCollector.Collect();
            _garbageCollector.WaitForPendingFinalizers();
            _garbageCollector.Collect();

            // warm up 
            func();

            IStopWatch watch = _stopWatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                func();
            }

            watch.Stop();
            WriteToConsole(description);
            WriteToConsole(string.Format("Time Elapsed {0} ms", watch.ElapsedMilliseconds));
        }

        private void WriteToConsole(string message)
        {
            if (_console != null)
            {
                _console.WriteLine(message);
            }
        }
    }
}
