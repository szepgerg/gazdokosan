using System;

namespace GazdOkosan.Model
{
    public class Jatekos
    {
    #region Adattagok
        private String _nev;
        private String _szin;
        private Int32 _osszeg;
        private Boolean _vanLakas;
        private Boolean _vanTakarek;
    #endregion

    #region Tulajdonsagok
        public Int32 Osszeg
        {
            get { return _osszeg; }
            set { _osszeg = value; }
        }
        public Boolean VanLakas
        {
            get { return _vanLakas; }
            set { _vanLakas = value; }
        }
        public Boolean VanTakarek
        {
            get { return _vanTakarek; }
            set { _vanTakarek = value; }
        }
    #endregion

    #region Konstruktorok
        public Jatekos(String nev, String szin, Int32 osszeg)
        {
            _nev = nev;
            _szin = szin;
            _osszeg = osszeg;
            _vanLakas = false;
            _vanTakarek = false;
        }
    #endregion
    }
}