using System.IO;
using System.Linq;
using NUnit.Framework;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.versiongo
{
    public class InitCommandTests : CommandTestBase
    {
        protected override string path => @"..\..\..\Assets";

        protected override string type => "version.go";

        [Test]
        public void Init_Versiongo_PathThrow()
        {
            var command = new[] { $"-init testingProject -type {type} -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        public void Init_Versiongo_ProjectNameThrow()
        {
            var command = new[] { $"-init -type {type} -path {path}" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        public void Init_Versiongo_Init()
        {
            var newPath = $"{path}\\{type}";
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            var command = new[] { $"-init testingProject -type {type} -path {path}" };
            var file =_vincreaser.Run(command);
            Assert.IsTrue(File.Exists(file.First()));
        }

        [Test]
        public void Init_Versiongo_IOException()
        {
            var command = new[] { $"-init testingProject -type {type} -path {path}" };
            Assert.Throws<IOException>(() => _vincreaser.Run(command));
        }

    }
}
