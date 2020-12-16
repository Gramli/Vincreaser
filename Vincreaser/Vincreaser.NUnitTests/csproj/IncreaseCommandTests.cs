using NUnit.Framework;
using System;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.csproj
{
    public class IncreaseCommandTests : CommandTestBase
    {
        protected override string path => "..\\..\\..\\Assets\\TestNetCoreSol";
        protected override string type => ".csproj";

        [Test]
        [Order(1)]
        public void IncreaseMajor_csproj_PathThrow()
        {
            var command = new[] { $"-increase major -type {type} -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(2)]
        public void IncreaseMajor_csproj_IncreaseThrow()
        {
            var command = new[] { $"-increase -type {type} -path {path}" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(3)]
        public void IncreaseMajor_csproj()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major +1, 0, 0, 0);

            var command = new[] { $"-increase major -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(4)]
        public void IncreaseMinor_csproj()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor+1, 0, 0);

            var command = new[] { $"-increase minor -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(5)]
        public void IncreaseRevision_csproj()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor, actualVersion.Build, actualVersion.Revision+1);

            var command = new[] { $"-increase revision -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(6)]
        public void IncreaseBuild_csproj()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor, actualVersion.Build + 1, 0);

            var command = new[] { $"-increase build -type {type} -path {path}" };
            DoAction(command, expected);
        }
    }
}