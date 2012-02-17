using System;

namespace pUnit
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProfileMethodAttribute : Attribute
    {
        private const int DefaultIterations = 1000;

        public int Iterations { get; set; }

        public ProfileMethodAttribute()
        {
            this.Iterations = DefaultIterations;
        }

        public ProfileMethodAttribute(int iterations)
        {
            this.Iterations = iterations;
        }
    }
}
