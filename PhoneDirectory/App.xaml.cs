using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PhoneDirectory.Interface;
using PhoneDirectory.ViewModel;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneDirectory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Register(Component.For<MainWindow>());
            container.Register(Component.For<PhoneViewModel>());
            container.Register(Component.For<IMessageBoxService>().ImplementedBy<MessageBoxService>());

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }

      
    }
}
