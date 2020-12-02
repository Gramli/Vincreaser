using System;
using System.Collections.Generic;

namespace VincreaserLib
{
    public class Vincreaser : IVincreaser
    {
        private readonly IEnumerable<IVersionFile> _versionFiles;
        public Vincreaser(IEnumerable<IVersionFile> versionFiles)
        {
            _versionFiles = versionFiles;
        }


        //COmmands dictionary with priorit - maybe class with interface
        //add logic for csproj to init all in folder
    }
}
