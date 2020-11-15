using System;
using VincreaserLib.Attributes;

namespace VincreaserLib
{
    public enum VersionChangerTypes
    {
        [Type("assemblyInfo.cs")]
        assemblyInfocs,
        [Type(".csproj")]
        csproj,
        [Type("version.go")]
        versiongo,
    }
}
