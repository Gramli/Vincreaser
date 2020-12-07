using Autofac;
using VincreaserLib.VersionChangers;
using VincreaserLib.VersionFiles;
using VincreaserLib.VincreaserCommands;

namespace VincreaserLib
{
    public class VincreaserLibContainer
    {
        private ContainerBuilder _containerBuilder;
        public VincreaserLibContainer()
        {
            Register();
        }

        public IContainer Build()
        {
            return _containerBuilder.Build();
        }

        private void Register()
        {
            _containerBuilder = new ContainerBuilder();

            RegisterVersionFiles();
            RegisterCommands();

            _containerBuilder.RegisterType<DirectoryBrowser>().As<IDirectoryBrowser>();
            _containerBuilder.RegisterType<VersionChanger>().As<IVersionChanger>();
            _containerBuilder.RegisterType<VincreaserCommandsManager>().As<IVincreaserCommandsManager>();
            _containerBuilder.RegisterType<Vincreaser>().As<IVincreaser>();
        }

        private void RegisterCommands()
        {
            _containerBuilder.RegisterType<ExcludeCommand>().As<IExcludeCommand>();
            _containerBuilder.RegisterType<IncreaseActionCommand>().As<IIncreaseActionCommand>();
            _containerBuilder.RegisterType<PathCommand>().As<IPathCommand>();
            _containerBuilder.RegisterType<SetActionCommand>().As<ISetActionCommand>();
            _containerBuilder.RegisterType<TypeCommand>().As<ITypeCommand>();
        }

        private void RegisterVersionFiles()
        {
            _containerBuilder.RegisterType<File_assemblyInfocs>().As<IVersionFile>();
            _containerBuilder.RegisterType<File_versiongo>().As<IVersionFile>();
            _containerBuilder.RegisterType<XML_csproj>().As<IVersionFile>();
        }
    }
}
