using NUnit.Framework;
using System;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.versiongo
{
    public class IncreaseCommandTests : CommandTestBase
    {
        protected override string path => "..\\..\\..\\Assets\\version.go";

        protected override string type => "version.go";

        [Test]
        [Order(1)]
        public void IncreaseMajor_Versiongo_PathThrow()
        {
            var command = new[] { $"-increase major -type {type} -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(2)]
        public void IncreaseMajor_Versiongo_IncreaseThrow()
        {
            var command = new[] { $"-increase -type {type} -path {path}" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(3)]
        public void IncreaseMajor_Versiongo()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major +1, 0, 0, 0);

            var command = new[] { $"-increase major -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(4)]
        public void IncreaseMinor_Versiongo()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor+1, 0, 0);

            var command = new[] { $"-increase minor -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(5)]
        public void IncreaseRevision_Versiongo()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor, actualVersion.Build, actualVersion.Revision+1);

            var command = new[] { $"-increase revision -type {type} -path {path}" };
            DoAction(command, expected);
        }

        [Test]
        [Order(6)]
        public void IncreaseBuild_Versiongo()
        {
            var actualVersion = Get();
            var expected = new Version(actualVersion.Major, actualVersion.Minor, actualVersion.Build + 1, 0);

            var command = new[] { $"-increase build -type {type} -path {path}" };
            DoAction(command, expected);
        }
    }
}