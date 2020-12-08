using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VincreaserLib.Attributes;

namespace VincreaserLib.Extensions
{
    public static class EnumExtension
    {
        public static string GetVersionFileType(this VersionFileType versionFileType)
        {
            var type = versionFileType.GetType();
            var attribute = (TypeAttribute)type.GetCustomAttributes(true).Single(i => i is TypeAttribute);
            return attribute.Name;
        }

        public static VersionFileType GetVersionFileType(this string stringValue)
        {
            var values = Enum.GetValues(typeof(VersionFileType)).Cast<VersionFileType>();

            foreach (var value in values)
            {
                if (GetVersionFileType(value) == stringValue)
                {
                    return value;
                }
            }

            throw new NullReferenceException($"Can't convert {stringValue} to VersionFileType");
        }
    }
}
