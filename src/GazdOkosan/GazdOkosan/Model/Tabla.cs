using System;

namespace GazdOkosan.Model
{
    public class Tabla
    {
    #region Adattagok
        private Mezo[] _mezok;
        private Kartya[] _kartyak;
        private Jatekos[] _jatekosok;
        private Int32 _jatekosSzam;
        private Int32 _kovJatekos;
    #endregion

    #region Tulajdonsagok
        public Int32 KovJatekos
            {
                get { return _kovJatekos; }
                set { _kovJatekos = value; }
            }
    #endregion

    #region Konstruktorok
        public Tabla(String[] nevek, String[] szinek, Int32 osszeg)
        { 
            //Mezok inicializalasa
            //Kartyak inicializalasa
            //Jatekosok inicializalasa
            _jatekosSzam = nevek.Length;
            _jatekosok = new Jatekos[_jatekosSzam];
            for (Int32 i = 0; i < _jatekosSzam; ++i)
            {
                _jatekosok[i] = new Jatekos(nevek[i], szinek[i], osszeg);
            }
            
            _kovJatekos = 1;
        }
    #endregion

    #region Metodusok
        public void Lepes()
        {
            //Jatekos atallitasa
            if (_kovJatekos == _jatekosSzam)
            {
                _kovJatekos = 1;
            }
            else
            {
                _kovJatekos++;
            }
        }
    #endregion
    }
}