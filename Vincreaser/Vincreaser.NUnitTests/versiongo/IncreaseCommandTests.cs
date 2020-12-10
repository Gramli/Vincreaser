using System.Linq;
using Autofac;
using NUnit.Framework;
using VincreaserLib;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.versiongo
{
    public class IncreaseCommandTests
    {
        private IVincreaser _vincreaser;

        [SetUp]
        public void Setup()
        {
            var container = new VincreaserLibContainer();

            var vincreaserContainer = container.Build();
            var scope = vincreaserContainer.BeginLifetimeScope();
            _vincreaser = scope.Resolve<IVincreaser>();
        }

        [Test]
        [Order(1)]
        public void IncreaseMajor_Versiongo_PathThrow()
        {
            var command = new[] { "-increase major -type version.go -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(2)]
        public void IncreaseMajor_Versiongo_IncreaseThrow()
        {
            var command = new[] { "-increase -type version.go -path Assets\\version.go" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(3)]
        public void IncreaseMajor_Versiongo()
        {
            var command = new[] { "-increase major -type version.go -path Assets\\version.go" };
            var version = _vincreaser.Run(command);
            Assert.AreEqual("1.9.0.0", version.First());
        }

        [Test]
        [Order(4)]
        public void IncreaseMinor_Versiongo()
        {
            var command = new[] { "-increase minor -type version.go -path Assets\\version.go" };
            var version = _vincreaser.Run(command);
            Assert.AreEqual("1.10.0.0", version.First());
        }

        [Test]
        [Order(5)]
        public void IncreasePatch_Versiongo()
        {
            var command = new[] { "-increase revision -type version.go -path Assets\\version.go" };
            var version = _vincreaser.Run(command);
            Assert.AreEqual("1.10.0.1", version.First());
        }

        [Test]
        [Order(6)]
        public void IncreaseBuild_Versiongo()
        {
            var command = new[] { "-increase build -type version.go -path Assets\\version.go" };
            var version = _vincreaser.Run(command);
            Assert.AreEqual("1.10.1.1", version.First());
        }
    }
}