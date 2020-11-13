using System;

namespace VincreaserLib.Attributes
{
    public class TypeAttribute : Attribute
    {
        public string Name { get; }
        public string[] FileNames { get; }

        public TypeAttribute(string name, params string[] fileNames)
        {
            Name = name;
            FileNames = fileNames;
        }
    }
}
