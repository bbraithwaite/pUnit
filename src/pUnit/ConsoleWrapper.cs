using System;

namespace pUnit
{
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void ReadLine()
        {
            Console.ReadLine();
        }
    }
}
