using System;
using System.IO;
using System.Reflection;

namespace pUnit
{
    public class ProfileRunner
    {
        private readonly IConsole _console;

        public virtual IGarbageCollector GarbageCollector
        {
            get { return new NativeGarbageCollector(); }
        }

        public virtual IStopWatch StopWatch
        {
            get { return new NativeStopWatch(); }
        }

        public ProfileRunner()
        {
            _console = new ConsoleWrapper();
        }

        public ProfileRunner(IConsole console)
        {
            _console = console;
        }

        public virtual string[] GetFiles()
        {
            return Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
        }

        public void Run()
        {
            string[] files = GetFiles();

            foreach (string file in files)
            {
                CheckAndProfileAssemblyMethods(file);
            }

            _console.ReadLine();
        }

        private void CheckAndProfileAssemblyMethods(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Profiler profiler = new Profiler(_console, GarbageCollector, StopWatch);
            foreach (Type type in assembly.GetTypes())
            {
                if (IsProfileClass(type))
                {
                    object instance = Activator.CreateInstance(type);

                    foreach (MethodInfo method in type.GetMethods())
                    {
                        ProfileMethodAttribute methodAttribute = GetProfileMethodAttribute(method);
                        if (methodAttribute != null)
                        {
                            MethodInfo methodToProfile = method;
                            profiler.Profile(method.Name, methodAttribute.Iterations, () => methodToProfile.Invoke(instance, null));
                        }
                    }
                }
            }
        }

        private static bool IsProfileClass(Type member)
        {
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                if (attribute is ProfileClassAttribute)
                {
                    return true;
                }
            }
            return false;
        }

        private static ProfileMethodAttribute GetProfileMethodAttribute(MemberInfo member)
        {
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                if (attribute is ProfileMethodAttribute)
                {
                    return attribute as ProfileMethodAttribute;
                }
            }
            return null;
        }
    }
}