using System;

namespace VincreaserLib.Attributes
{
    public class TypeAttribute : Attribute
    {
        public string Name { get; }

        public TypeAttribute(string name)
        {
            Name = name;
        }
    }
}
