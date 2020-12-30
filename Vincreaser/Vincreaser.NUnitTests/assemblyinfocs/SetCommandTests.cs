using NUnit.Framework;
using System;
using System.Linq;
using VincreaserLib.Exceptions;

namespace Vincreaser.NUnitTests.assemblyinfocs
{
    public class SetCommandTests : CommandTestBase
    {
        protected override string path => "..\\..\\..\\Assets\\TestAssemblyInfoSol";

        protected override string type => "assemblyInfo.cs";

        [Test]
        [Order(1)]
        public void Set_assemblyinfocs_SetThrow()
        {
            var command = new[] { $"-set -type {type} -path {path}" };
            Assert.Throws<UnknownCommand>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(2)]
        public void Set_assemblyinfocs_SetThrow_Version()
        {
            var command = new[] { $"-set abs -type {type} -path {path}" };
            Assert.Throws<ArgumentException>(() => _vincreaser.Run(command));
        }

        [Test]
        [Order(3)]
        public void Set_assemblyinfocs()
        {
            var command = new[] { $"-set 0.0.0.0 -type {type} -path {path}" };
            var result = _vincreaser.Run(command);
            Assert.AreEqual("0.0.0.0", result.First());
        }
    }
}
