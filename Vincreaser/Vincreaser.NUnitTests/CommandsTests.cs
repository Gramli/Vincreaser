using NUnit.Framework;
using VincreaserLib;
using Autofac;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests
{
    public class CommandsTests
    {
        private IVincreaser _vincreaser;

        [SetUp]
        public void Setup()
        {
            var container = new VincreaserLibContainer();

            var vincreaserContainer = container.Build();
            using var scope = vincreaserContainer.BeginLifetimeScope();
            _vincreaser = scope.Resolve<IVincreaser>();
        }

        [Test]
        public void IncreaseMajor_Versiongo_Throw()
        {
            var command = new[] { "-increase major -type version.go -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }
    }
}