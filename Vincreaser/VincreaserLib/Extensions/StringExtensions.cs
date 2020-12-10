using System;
using System.Linq;
using System.Text;

namespace VincreaserLib.Extensions
{
    public static class StringExtensions
    {
        public static string SubStringBetween(this string value, char left, char right)
        {
            var result = new StringBuilder();
            var add = false;

            foreach (var character in value)
            {
                
                if (character == left)
                {
                    add = true;
                    continue;
                }

                if (character == right)
                {
                    return result.ToString();
                }

                if (add)
                {
                    result.Append(character);
                }
            }

            throw new Exception($"Missing left{left} or right{right} argument in value{value}.");
        }

        public static string[] SplitAndRemoveSpaces(this string value, char separator)
        {
            return value.Split(separator).Where(i => !string.IsNullOrEmpty(i)).ToArray();
        }

        public static string ReplaceQuotesAndBackslashes(this string value)
        {
            return value.Replace("\\", "").Replace("\"","").Replace(" ","");
        }
    }
}
