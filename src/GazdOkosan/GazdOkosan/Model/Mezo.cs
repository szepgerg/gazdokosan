using System;
using System.Collections.Generic;
using System.Linq;

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
            public virtual event EventHandler<MezoArgumentumok> Lepes;
                protected virtual void Lepeskor(Int32 lepesszam)
                {
                    if (Lepes != null)
                        Lepes(this, new MezoArgumentumok(lepesszam));
                }
            public virtual event EventHandler<EventArgs> EgyVagyHatJatekos;
                protected virtual void EgyVagyHatJatekoskor()
                {
                    if (EgyVagyHatJatekos != null)
                            EgyVagyHatJatekos(this, new EventArgs());
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
            public virtual void Kezel(Jatekos jatekos, Int32 index)
            { 
            }
        #endregion
    }

    // KESZ VAN.
    /// <summary>
    /// A tranzakcios mezoket megvalosito osztaly.
    /// </summary>
    public class TranzakciosMezo : Mezo
    {
        // A jatekos fix osszeget fizet/kap(Egyszeru), a jatekos vasarolhat egy listarol(Listas), 
        // a jatekosnak feltetelhez kototten fizetnek(Felteteles).
        #region Adattagok
            public enum Tipus { Egyszeru, Listas, Felteteles, Torleszto};
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
                    default:
                        break;
                }
                
            }
            public override void Kezel(Jatekos jatekos, Int32 index)
            {
                // A lista index-edik elemet megveszi.
                // 0-tol indexelt.
                index--;
                Int32 ar = _lista[_lista.Keys.ToList()[index]];
                jatekos.Osszeg = jatekos.Osszeg - ar;
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

    // KESZ VAN.
    /// <summary>
    /// A lepteto mezoket megvalosito osztaly.
    /// </summary>
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

    // KESZ VAN.
    /// <summary>
    /// A specialis mezoket megvalosito osztaly.
    /// </summary>
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
                if (Azonosito == 30)
                {
                    // Esemeny a Tabla-nak, mely jelzi, hogy az aktualis jatekos csak 1/6 dobassal mehet tovabb.
                    EgyVagyHatJatekoskor();
                }
                else
                { 
                    // 5-os mezo.
                    // Csak szoveg megjelenitese.
                }
            }
        #endregion
    }
}