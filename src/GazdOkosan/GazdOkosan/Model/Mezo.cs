using System;
using System.Collections.Generic;

namespace GazdOkosan.Model
{
    public class Mezo
    {
        #region Adattagok
            private Int32 _azonosito;
            private String _leiras;
        #endregion

        #region Tulajdonsagok
            public Int32 Azonosito
            {
                get { return _azonosito; }
                set { _azonosito = value; }
            }
            public String Leiras
            {
                get { return _leiras; }
                set { _leiras = value; }
            }
            public virtual Boolean EgyVagyHat
            {
                get;
                set;
            }
        #endregion

        #region Esemenyek
            public event EventHandler<EventArgs> KartyaHuzas;
                protected void KartyaHuzaskor()
                {
                    if (KartyaHuzas != null)
                            KartyaHuzas(this, new EventArgs());
                }
            public event EventHandler<EventArgs> Dobas;
                protected void Dobaskor()
                {
                    if (Dobas != null)
                        Dobas(this, new EventArgs());
                }
            public virtual event EventHandler<MezoArgumentumok> Lepes;
                protected virtual void Lepeskor(Int32 lepesszam)
                {
                    if (Lepes != null)
                        Lepes(this, new MezoArgumentumok(lepesszam));
                }
        #endregion

        #region Konstruktorok
            public Mezo()
            {

            }
        #endregion

        #region Metodusok
            public virtual void Kezel(Jatekos jatekos)
            { 
                
            }
        #endregion
    }

    public class TranzakciosMezo : Mezo
    {
        // A jatekos fix osszeget fizet/kap(Egyszeru), a jatekos vasarolhat egy listarol(Listas), 
        // a jatekosnak feltetelhez kototten fizetnek(Felteteles).
        #region Adattagok
            public enum Tipus { Egyszeru, Listas, Felteteles};
            private Int32 _osszeg;
            private Tipus _tipus;
            private Dictionary<String, Int32> _lista;
        #endregion

        #region Konstruktorok
            public TranzakciosMezo(Int32 azonosito, String leiras, Tipus tipus, Int32 osszeg)
            {
                Azonosito = azonosito;
                Leiras = leiras;
                _tipus = tipus;
                _osszeg = osszeg;
            }
            public TranzakciosMezo(Int32 azonosito, String leiras, Tipus tipus, Int32 osszeg, Dictionary<String, Int32> lista)
            {
                Azonosito = azonosito;
                Leiras = leiras;
                _tipus = tipus;
                _osszeg = osszeg;
                _lista = lista;
            }
        #endregion

        #region Metodusok
            public override void Kezel(Jatekos jatekos)
            {
                switch (_tipus)
                {
                    case Tipus.Egyszeru:
                        // Mindig kivonas, mivel ha a jatekos kap az osszeg negativ.
                        jatekos.Osszeg = jatekos.Osszeg - _osszeg;
                        break;
                    case Tipus.Felteteles:
                        if (Azonosito == 3)
                        {
                            // A takarekbetetek utan 5% jar.
                            if (jatekos.Takarek != 0)
                            {
                                jatekos.Osszeg = jatekos.Osszeg + (jatekos.Takarek / 100) * 5;
                            }
                        }
                        else
                        { 
                            // Ha van CSEB-biztositas, jar 5000 Ft.
                            if (jatekos.VanCSEB)
                            {
                                jatekos.Osszeg = jatekos.Osszeg + 5000;
                            }
                        }
                        break;
                    case Tipus.Listas:
                        break;
                    default:
                        break;
                }
            }
        #endregion
    }

    public class SzerencseMezo : Mezo
    {
        // Azon mezok ahol a jatekos szerencsekartyat huzhat.
         #region Konstruktorok
            public SzerencseMezo(Int32 azonosito, String leiras)
            {
                Azonosito = azonosito;
                Leiras = leiras;
            }
        #endregion

        #region Metodusok
            public override void Kezel(Jatekos jatekos)
            {
                // Esemeny a Tablanak, ami a Kartyahuzas()-ra van kotve.
                KartyaHuzaskor();
            }
        #endregion
    }

    public class LeptetoMezo : Mezo
    {
        // A jatekos lephet valamennyit, illetve ujradobhat.
        #region Adattagok
            private Int32 _lepesszam;
            private Boolean _ujradobas;
        #endregion

        #region Esemenyek
            public override event EventHandler<MezoArgumentumok> Lepes;
                protected override void Lepeskor(Int32 lepesszam)
                {
                    if (Lepes != null)
                            Lepes(this, new MezoArgumentumok(lepesszam));
                }
        #endregion

        #region Konstruktorok
        public LeptetoMezo(Int32 azonosito, String leiras, Int32 lepesszam, Boolean ujradobas)
            {
                Azonosito = azonosito;
                Leiras = leiras;
                _lepesszam = lepesszam;
                _ujradobas = ujradobas;
            }
        #endregion
        
        #region Metodusok
            public override void Kezel(Jatekos jatekos)
            {
                if (_ujradobas)
                {
                    // Esemenydobas a Tablanak, ami a Dobas()-ra van kotve.
                    Dobaskor();
                }
                else 
                {
                    // Esemenydobas a Tablanak, ami a Lepes(_lepesszam)-ra van kotve.
                    Lepeskor(_lepesszam);
                }
            }
        #endregion
    }

    public class SpecialisMezo : Mezo
    {
        // A jatekos csak akkor mehet tovabb ha 1-es illetve 6-ost dobott(30-as mezo)
        // csak egy szoveget kell megjeleniteni, semmi hatasa nincsen(5-os mezo).
        #region Adattagok
            private Boolean _egyVagyHat;
        #endregion

        #region Konstruktorok
        public SpecialisMezo(Int32 azonosito, String leiras)
            {
                Azonosito = azonosito;
                Leiras = leiras;
                if (Azonosito == 30)
                {
                    _egyVagyHat = true;
                }
                else
                {
                    _egyVagyHat = false;
                }
            }
        #endregion

        #region Tulajdonsagok
            public override Boolean EgyVagyHat
            {
                get { return _egyVagyHat; }
                set { _egyVagyHat = value; }
            }
        #endregion

        #region Metodusok
        public override void Kezel(Jatekos jatekos)
            {
                // !!!!!!!!!!
                if (Azonosito == 5)
                {
                    // Csak a szoveg megjelenitese.
                }
                else
                { 
                    // 30-as mezo. 
                }
            }
        #endregion
    }
}