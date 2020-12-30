using System.IO;
using System.Linq;
using NUnit.Framework;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.assemblyinfocs
{
    public class InitCommandTests : CommandTestBase
    {
        protected override string path => "..\\..\\..\\Assets\\TestAssemblyInfoSol";

        protected override string type => "assemblyInfo.cs";

        [Test]
        public void Init_Assemblyinfo_PathThrow()
        {
            var command = new[] { $"-init testingProject -type {type} -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        public void Init_assemblyInfo_ProjectNameThrow()
        {
            var command = new[] { $"-init -type {type} -path {path}" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        public void Init_assemblyInfo_IOException()
        {
            var command = new[] { $"-init TestAssemblyInfo -type {type} -path {path}" };
            Assert.Throws<IOException>(() => _vincreaser.Run(command));
        }

        [Test]
        public void Init_assemblyInfo_Init()
        {
            var newPath = $"{path}\\TestFolder";

            if(Directory.Exists(newPath))
            {
                Directory.Delete(newPath, true);
            }
            Directory.CreateDirectory(newPath);

            var command = new[] { $"-init TestAssemblyInfo -type {type} -path {newPath}" };
            var result = _vincreaser.Run(command);
            Assert.True(File.Exists(result.First()));
        }

    }
}
