using System;
using System.Collections.Generic;

namespace GazdOkosan.Model
{
    public class Jatekos
    {
        #region Adattagok
            private String _nev;
            private String _szin;
            private Int32 _pozicio;
            private Int32 _osszeg;
            private int _tartozas;
            private Int32 _takarek;
            private Boolean _vanLakas;
            private Boolean _vanCSEB;
            private Boolean _vanLakasbizt;
            private Boolean _vanKonyvut;
            private List<String> _butor;
        #endregion

        #region Tulajdonsagok
            public String Nev
            {
                get { return _nev; }
                set { _nev = value; }
            }
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
            public int Tartozas
            {
                get { return _tartozas; }
                set { _tartozas = value; }
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
            public Boolean VanLakasbizt
            {
                get { return _vanLakasbizt; }
                set { _vanLakasbizt = value; }
            }
            public Boolean VanKonyvut
            {
                get { return _vanKonyvut; }
                set { _vanKonyvut = value; }
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
                _butor = new List<String>();
            }
        #endregion

        /// <summary>
        /// Megvizsgálja hogy <param>butor</param> megtalálható-e a Játékos <list>_butor</list> listájában, és <code>true</code> ha megatlálható
        /// <code>false</code> ha nem.
        /// </summary>
        /// <param name="butor">A vizsgálandó bútor darab.</param>
        /// <returns>True vagy false attól függően megtalálható-e az adott <code>butor</code> a Játékos listájában.</returns>
        public Boolean VanButor(String butor)
        {
            return _butor.Contains(butor);
        }

        /// <summary>
        /// Hozzáadja az adott <param>butor</param> darabot a Játékos bútor listájához.
        /// </summary>
        /// <param name="butor">A hozzáadandó bútor darab.</param>
        public void AdButor(String butor)
        {
            _butor.Add(butor);
        }

        /// <summary>
        /// Visszatér a Játékos bútor darabjainak listájával.
        /// </summary>
        /// <returns>A Játékos által bírtokolt bútorok listája</returns>
        public List<String> Butor()
        {
            return _butor;
        }
    }
}