using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using CefSharp.WinForms;
using Launcher.Controls;
using Launcher.Core;
using NLog;
using LogManager = NLog.LogManager;

namespace Launcher
{
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionContainer _container;
        private readonly string _modulesPath = Path.GetFullPath(@"../../../../Modules");
        private static Logger logger = LogManager.GetCurrentClassLogger();
        

        public AppBootstrapper()
        {
            Initialize();
        }

        //Для теста
        public AppBootstrapper(string path)
        {
         
            _modulesPath = path;
            //PlatformProvider.Current = new XamlPlatformProvider();
            StartDesignTime();
        }

        protected override void Configure()
        {
            logger.Trace("Configure");
            var catalog = new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)));

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(new User());
            batch.AddExportedValue(new ChromiumWebBrowser("about:config"));
           
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
            var startupTasks =
                GetAllInstances(typeof(StartupTask))
                .Cast<ExportedDelegate>()
                .Select(exportedDelegate => (StartupTask)exportedDelegate.CreateDelegate(typeof(StartupTask)));

            startupTasks.Apply(s => s());

            DisplayRootViewFor<IShell>();
        }
    }
}