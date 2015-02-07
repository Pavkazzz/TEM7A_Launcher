using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Launcher.Core;
using Launcher.Model;

namespace Launcher
{
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionContainer _container;
        private string _modulesPath = Path.GetFullPath(Path.GetFullPath(@"../../../../Modules"));

        public AppBootstrapper()
        {
            Initialize();

        }

        public AppBootstrapper(string path)
        {
            Initialize();
            _modulesPath = path;
        }

        protected override void Configure()
        {
            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)));

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(new MainModel());
            batch.AddExportedValue(new User());

            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }

        protected override object GetInstance(Type service, string key)
        {
            var contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblyList = new List<Assembly> {Assembly.GetExecutingAssembly()};

            //Грузим все модули из папки
            assemblyList.AddRange(
                from file in Directory.GetFiles(_modulesPath, "*.dll")
                where file.Contains("Launcher.")
                select Assembly.LoadFile(file));

            return assemblyList.ToArray();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}