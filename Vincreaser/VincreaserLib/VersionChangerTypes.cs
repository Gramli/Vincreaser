using System;
using VincreaserLib.Attributes;

namespace VincreaserLib
{
    public enum VersionChangerTypes
    {
        [Type("assemblyInfo")]
        AssemblyInfo,
        [Type(".csproj")]
        csproj,
    }
}
