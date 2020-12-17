using System.IO;
using System.Linq;
using NUnit.Framework;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.csproj
{
    public class InitCommandTests : CommandTestBase
    {
        protected override string path => "..\\..\\..\\Assets\\TestNetCoreSol";

        protected override string type => ".csproj";

        [SetUp]
        public void CreateFolder()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        [TearDown]
        public void DeleteFolder()
        {
            Directory.Delete(path, true);
        }

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
        public void Init_assemblyInfo_Init()
        {
            var command = new[] { $"-init testingProject -type {type} -path {path}" };
            var file =_vincreaser.Run(command);
            Assert.IsTrue(File.Exists(file.First()));
        }

    }
}
