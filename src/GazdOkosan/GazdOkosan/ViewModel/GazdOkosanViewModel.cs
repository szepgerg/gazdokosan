using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GazdOkosan.Model;

namespace GazdOkosan.ViewModel
{
    public class GazdOkosanViewModel : ViewModelBase
    {
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand HelpCommand { get; private set; }

        Tabla tabla;

        /*public event EventHandler NewGame;
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

        public void ujJatek(String[] nevek, int kezdoOsszeg)
        {
            String[] szinek = { "piros", "kék", "zöld", "sárga" };

            tabla = new Tabla(nevek, szinek, kezdoOsszeg);
        }

        public void dobas()
        {
            tabla.Dobas();
        }

        public void takarekbetet(int osszeg)
        {
            tabla._jatekosok[tabla.KovJatekos].Takarek = osszeg;
        }

        public void hazVasarlas()
        {
            if (tabla._jatekosok[tabla.KovJatekos].Osszeg >= 30000)
            {
                tabla._jatekosok[tabla.KovJatekos].Osszeg -= 30000;
                tabla._jatekosok[tabla.KovJatekos].VanLakas = true;
                tabla._jatekosok[tabla.KovJatekos].Tartozas = 40000;
            }
        }

        public void torleszt(int osszeg)
        {
            tabla._jatekosok[tabla.KovJatekos].Tartozas -= osszeg;
        }*/
    }
}
