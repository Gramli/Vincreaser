using Autofac;
using NUnit.Framework;
using System;
using System.Linq;
using VincreaserLib;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.versiongo
{
    public class SetCommandTests
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
        public void Set_Versiongo_SetThrow()
        {
            var command = new[] { "-set -type version.go -path Assets\\version.go" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(2)]
        public void Set_Versiongo_SetThrow_Version()
        {
            var command = new[] { "-set abs -type version.go -path Assets\\version.go" };
            Assert.Throws<ArgumentException>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(3)]
        public void Set_Versiongo()
        {
            var command = new[] { "-set 0.0.0 -type version.go -path Assets\\version.go" };
            var result = _vincreaser.Run(command);
            Assert.AreEqual("0.0.0",result.First());
        }
    }
}
