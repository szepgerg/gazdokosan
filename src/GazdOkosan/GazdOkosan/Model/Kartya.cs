using System;

namespace GazdOkosan.Model
{
    public class Kartya
    {
    #region Adattagok
        private String _leiras;
        private String _muvelet;
        private Int32 _ertek;
    #endregion

    #region Konstruktorok
        public Kartya(String leiras, String muvelet, Int32 ertek)
        {
            _leiras = leiras;
            _muvelet = muvelet;
            _ertek = ertek;
        }
    #endregion
    }
}