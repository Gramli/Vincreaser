using Autofac;
using NUnit.Framework;
using System;
using System.Linq;
using VincreaserLib;

namespace Vincreaser.NUnitTests
{
    public abstract class IncreaseCommandBase
    {
        protected IVincreaser _vincreaser;

        protected abstract string path { get; }
        protected abstract string type { get; }

        [SetUp]
        public void Setup()
        {
            var container = new VincreaserLibContainer();

            var vincreaserContainer = container.Build();
            var scope = vincreaserContainer.BeginLifetimeScope();
            _vincreaser = scope.Resolve<IVincreaser>();
        }
        protected Version Get()
        {
            var command = new[] { $"-get -type {type} -path {path}" };
            var version = _vincreaser.Run(command);
            return new Version(version.First());
        }

        protected void DoAction(string[] command, Version expected)
        {
            var version = _vincreaser.Run(command);
            Assert.AreEqual(expected.ToString(), version.First());
        }
    }
}
