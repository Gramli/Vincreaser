using System;
using System.Linq;
using VincreaserLib.Attributes;

namespace VincreaserLib.Extensions
{
    public static class EnumExtension
    {
        public static string GetVersionFileType(this VersionFileType versionFileType)
        {
            var type = versionFileType.GetType();
            var memberInfo = type.GetMember(versionFileType.ToString()).First();
            var attribute = (TypeAttribute)memberInfo.GetCustomAttributes(typeof(TypeAttribute), false).Single();
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
