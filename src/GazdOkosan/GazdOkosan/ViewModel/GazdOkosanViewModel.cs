using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GazdOkosan.ViewModel
{
    public class GazdOkosanViewModel : ViewModelBase
    {
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand HelpCommand { get; private set; }

        public event EventHandler NewGame;
        public event EventHandler Help;

        public GazdOkosanViewModel()
        {
            NewGameCommand = new DelegateCommand(x => NewGameExecuted());
            ExitCommand = new DelegateCommand(x => ExitExecuted());
            HelpCommand = new DelegateCommand(x => HelpExecuted());
        }

        private void NewGameExecuted()
        {
            if (NewGame != null)
                NewGame(this, EventArgs.Empty);
        }

        private void ExitExecuted()
        {
            Application.Current.Shutdown();
        }

        private void HelpExecuted()
        {
            if (Help != null)
                Help(this, EventArgs.Empty);
        }
    }
}
