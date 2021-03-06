﻿using System;
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
        public DelegateCommand DobasParancs { get; private set; }

        private Tabla tabla;

        public event EventHandler NewGame;
        public event EventHandler Help;
        public event EventHandler Dobas;

        public GazdOkosanViewModel()
        {
            NewGameCommand = new DelegateCommand(x => NewGameExecuted());
            ExitCommand = new DelegateCommand(x => ExitExecuted());
            HelpCommand = new DelegateCommand(x => HelpExecuted());
            DobasParancs = new DelegateCommand(x => DobasExecute());
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

        /// <summary>
        /// Az "Új játék" gomb lenyomásakor létrehoz egy Tábla pédányt.
        /// </summary>
        /// <param name="nevek">A játékosok neveit tartalmazó tömb.</param>
        /// <param name="kezdoOsszeg">A beálított kezdőösszeg, amivel minden játékos rendelkezik a játék elején.</param>
        public void UjJatek(String[] nevek, int kezdoOsszeg)
        {
            String[] szinek = { "piros", "kék", "zöld", "sárga" };

            tabla = new Tabla(nevek, szinek, kezdoOsszeg);
        }

        /// <summary>
        /// A "Dobás" gomb lenyomásakor végrehajtódik a Tábla osztály Dobás metódusa.
        /// </summary>
        public void DobasExecute()
        {
            tabla.Dobas();
        }

        /// <summary>
        /// A "Takarékbetétkönyv váltás" gomb lenyomásakor, a Játékos takarékbetétkönyvet válthat egy általa megadott összegben.
        /// </summary>
        /// <param name="osszeg">Az összeg amennyiért a Játékos takarékbetétkönyvet akar váltani.</param>
        public void Takarekbetet(Int32 osszeg)
        {
            tabla.TakarekbetetModell(osszeg);
        }

        /// <summary>
        /// Ha a Játékos a 14-es mezőre lép és 30.000Ft-tól több pénze van vehet egy lakást, tartozása 40.000Ft lesz.
        /// </summary>
        public void HazVasarlas_14()
        {
            tabla.HazVasarlas14Modell();
        }

        /// <summary>
        /// Ha a Játékos a 26-os mezőre lép és 40.000Ft-tól több pénze van vehet egy lakást, tartozása 30.000Ft lesz.
        /// </summary>
        public void HazVasarlas_26()
        {
            tabla.HazVasarlas26Modell();
        }

        /// <summary>
        /// Ha a Játékosnak van 70.000Ft-ja, vehet egy lakást magának egyben kifizetve annak árát, bárhol legyen a játéktáblán.
        /// </summary>
        public void HazVasarlas()
        {
            tabla.HazvasarlasModell();
        }

        /// <summary>
        /// Ha a Játékosnak tartozása van és van elegendő pénze, akkor az általa megadott összeg levonásra kerül a tartozásából.
        /// </summary>
        /// <param name="osszeg">A törlesztendő összeg.</param>
        public void Torleszt(Int32 osszeg)
        {
            tabla.TorlesztModell(osszeg);
        }

        /// <summary>
        /// A Játékos 150Ft ellenében Család és Élet Biztosítást válthat.
        /// </summary>
        public void CSEB_valtas()
        {
            tabla.CSEBvaltasModell();
        }

        /// <summary>
        /// A Játékos 200Ft ellenében Lakásbiztosítást válthat.
        /// </summary>
        public void Lakasbizt_valtas()
        {
            tabla.LakasbiztvaltasModell();
        }
    }
}
