using System;

namespace ConsoleApp2
{
    /// <summary>
    /// dog
    /// </summary>
    public class DogAttribute : Attribute
    {
        public string Name { get; set; }
        public double Age { get; set; }

        public DogAttribute(string name)
        {
            this.Name = name;
        }
    }
}