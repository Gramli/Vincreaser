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
            var scope = vincreaserContainer.BeginLifetimeScope();
            _vincreaser = scope.Resolve<IVincreaser>();
        }

        [Test]
        public void IncreaseMajor_Versiongo_PathThrow()
        {
            var command = new[] { "-increase major -type version.go -path someUsdadas" };
            Assert.Throws<PathException>(() => _vincreaser.Run(command));
        }

        [Test]
        public void IncreaseMajor_Versiongo_IncreaseThrow()
        {
            var command = new[] { "-increase  -type version.go -path Assests\version.go" };
            _vincreaser.Run(command);
        }

        [Test]
        public void IncreaseMajor_Versiongo()
        {
            var command = new[] { "-increase major -type version.go -path Assests\version.go" };
            _vincreaser.Run(command);
        }
    }
}