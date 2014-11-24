using System;

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
        // A jatekos fix osszeget fizet(Negativ), a jatekos vasarolhat egy listarol(Listas), 
        // a jatekosnak fix osszeget fizetnek(Pozitiv), a jatekosnak feltetelhez kototten fizetnek(Felteteles).
        #region Adattagok
            public enum Tipus { Negativ, Listas, Pozitiv, Felteteles};
            private Int32 _osszeg;
            private Tipus _tipus;
        #endregion

        #region Konstruktorok
            public TranzakciosMezo(Int32 azonosito, String leiras, Tipus tipus, Int32 osszeg)
            {
                Azonosito = azonosito;
                Leiras = leiras;
                _tipus = tipus;
                _osszeg = osszeg;
            }
        #endregion

        #region Metodusok
            public override void Kezel(Jatekos jatekos)
            {
                // !!!!!!!!!!
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
                // !!!!!!!!!!
                if (_ujradobas)
                {
                    // Esemenydobas a Tablanak, ami a Dobas()-ra van kotve.
                    Dobaskor();
                }
                else 
                { 
                   // Esemenydobas a Tablanak, ami a Lepes(_lepesszam)-ra van kotve.
                }
            }
        #endregion
    }

    public class SpecialisMezo : Mezo
    {
        // A jatekos csak akkor mehet tovabb ha 1-es illetve 6-ost dobott(30-as mezo)
        // csak egy szoveget kell megjeleniteni, semmi hatasa nincsen(5-os mezo).
        #region Konstruktorok
            public SpecialisMezo(Int32 azonosito, String leiras)
            {
                Azonosito = azonosito;
                Leiras = leiras;
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