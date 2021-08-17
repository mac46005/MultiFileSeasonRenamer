using Caliburn.Micro;
using FileRenamer_WPF.ViewModels;
using MultiFileRenamer.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FileRenamer_WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            _container
                .PerRequest<FolderBrowserDialog, FolderBrowserDialog>()
                .PerRequest<FolderContentsRenamer, FolderContentsRenamer>();

            GetType().Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(vmType => _container.RegisterPerRequest(vmType, vmType.ToString(), vmType));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
