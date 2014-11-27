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

            public String Leiras
            {
                get { return _leiras; }
                set { _leiras = value; }
            }

            public String Muvelet
            {
                get { return _muvelet; }
                set { _muvelet = value; }
            }

            public Int32 Ertek
            {
                get { return _ertek; }
                set { _ertek = value; }
            }

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