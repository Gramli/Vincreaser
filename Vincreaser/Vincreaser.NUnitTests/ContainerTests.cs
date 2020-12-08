using Autofac;
using NUnit.Framework;
using VincreaserLib;

namespace Vincreaser.NUnitTests
{
    public class ContainerTests
    {
        [Test]
        public void BuildContainer_And_Resolve()
        {
            var container = new VincreaserLibContainer();
            var vincreaserContainer = container.Build();
            using var scope = vincreaserContainer.BeginLifetimeScope();
            var _vincreaser = scope.Resolve<IVincreaser>();
        }
    }
}
