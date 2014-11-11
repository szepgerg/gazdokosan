using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GazdOkosan.View;
using GazdOkosan.ViewModel;

namespace GazdOkosan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private GazdOkosanViewModel _ViewModel;
        private MainWindow _MainWindow;
        private NewGameWindow _NewGameWindow;
        private HelpWindow _HelpWindow;

        public App()
        {
            _ViewModel = new GazdOkosanViewModel();
            _ViewModel.NewGame += new EventHandler(ViewModel_NewGame);
            _ViewModel.Help += new EventHandler(ViewModel_Help);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _MainWindow = new MainWindow();
            _MainWindow.DataContext = _ViewModel;
            _MainWindow.Show();
        }

        private void ViewModel_NewGame(object sender, EventArgs e)
        {
            _NewGameWindow = new NewGameWindow();
            _NewGameWindow.DataContext = _ViewModel;
            _NewGameWindow.Show();
        }

        private void ViewModel_Help(object sender, EventArgs e)
        {
            _HelpWindow = new HelpWindow();
            _HelpWindow.DataContext = _ViewModel;
            _HelpWindow.Show();
        }
    }
}
