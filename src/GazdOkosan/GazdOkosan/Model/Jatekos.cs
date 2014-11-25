using System;

namespace GazdOkosan.Model
{
    public class Jatekos
    {
        #region Adattagok
            private String _nev;
            private String _szin;
            private Int32 _pozicio;
            private Int32 _osszeg;
            private Int32 _takarek;
            private Boolean _vanLakas;
            private Boolean _vanCSEB;
        #endregion

        #region Tulajdonsagok
            public Int32 Pozicio
            {
                get { return _pozicio; }
                set { _pozicio = value; }
            }
            public Int32 Osszeg
            {
                get { return _osszeg; }
                set { _osszeg = value; }
            }
            public Int32 Takarek
            {
                get { return _takarek; }
                set { _takarek = value; }
            }
            public Boolean VanLakas
            {
                get { return _vanLakas; }
                set { _vanLakas = value; }
            }
            public Boolean VanCSEB
            {
                get { return _vanCSEB; }
                set { _vanCSEB = value; }
            }
            
        #endregion

        #region Konstruktorok
            public Jatekos(String nev, String szin, Int32 osszeg)
            {
                _nev = nev;
                _szin = szin;
                _pozicio = 0;
                _osszeg = osszeg;
                _takarek = 0;
                _vanLakas = false;
            }
        #endregion
    }
}