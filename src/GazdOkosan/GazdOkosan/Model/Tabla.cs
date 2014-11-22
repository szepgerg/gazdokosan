using System;
using System.Collections.Generic;

namespace GazdOkosan.Model
{
    public class Tabla
    {
        #region Adattagok
            private Mezo[] _mezok;
            private Dictionary<Int32, String> _leirasok;
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
                // Mezok inicializalasa.
                _mezok = new Mezo[39];
                Leiras_Inicializalas();
                SZM_Inicializalas();
                LM_Inicializalas();
                SM_Inicializalas();

                // Kartyak inicializalasa.

                // Jatekosok inicializalasa.
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
            /// <summary>
            /// A leirasokat inicializalo metodus.
            /// </summary>
            private void Leiras_Inicializalas()
            {
                _leirasok = new Dictionary<Int32, String>();
                _leirasok.Add(10, "Expresszvonattal gyorsabban érsz célba, lépj a 15-ös mezőre!");
                _leirasok.Add(11, "Gondtalan utazás az IBUSZ-al! Dobhatsz még egyszer!");
                _leirasok.Add(12, "Leveleidre jól írtad rá az irányítószámot, lépj előre két mezőt!");
                _leirasok.Add(19, "Minden reggel tornázol, ezért lépj előre három mezőt!");
                _leirasok.Add(20, "Repülővel utaztál, gyorsan célba értél. Lépj előre a 22-es mezőre!");
                _leirasok.Add(21, "Rendszeresen tisztálkodsz, reggel és este megmosod a fogadat, jutalomból kétszer dobhatsz!");
                _leirasok.Add(23, "Segíted az időseket, jutalomból még egyszer dobhatsz!");
                _leirasok.Add(27, "A GELKA gyorsan megjavította készülékeidet, hamarabb elmehetsz otthonról. Lépj előre egy mezőt!");
                _leirasok.Add(28, "A KRESZ szerint a kerékpárra szerelendő tartozékokat felsoroltad, dobhatsz még egyszer!");
                _leirasok.Add(33, "Gyalogátkelés előtt figyelmesen körülnéztél. Jutalomból lépj előre a 2-es mezőre!");
                _leirasok.Add(37, "Rejtvénypályázaton országjáró utazást nyertél, lépj a 39-es mezőre!");
                _leirasok.Add(39, "Hétvégi pihenésedet túrázással töltötted a szabadban, még egyszer dobhatsz!");
                _leirasok.Add(2, "Húzz egy szerencsekártyát!");
                _leirasok.Add(9, "Húzz egy szerencsekártyát!");
                _leirasok.Add(15, "Húzz egy szerencsekártyát!");
                _leirasok.Add(22, "Húzz egy szerencsekártyát!");
                _leirasok.Add(31, "Húzz egy szerencsekártyát!");
                _leirasok.Add(35, "Húzz egy szerencsekártyát!");
                _leirasok.Add(5, "A budapesti víz Európa egyik legjobb ivóvize. Zárd el jól a csapot, hogy ne folyjon feleslegesen!");
                _leirasok.Add(30, "Nyári táborban pihensz. A pihenés el is húzódhat, mert csak 1-es vagy 6-os dobással mehetsz tovább!");
            }

            /// <summary>
            /// Szerencsemezok inicializalasa.
            /// </summary>
            private void SZM_Inicializalas()
            {
                Int32[] elemek = new Int32[6]{2, 9, 15, 22, 31, 35};
                for (Int32 i = 0; i < elemek.Length; ++i )
                {
                    String leiras;
                    _leirasok.TryGetValue(i, out leiras);
                    _mezok[i] = new SzerencseMezo(i, leiras);
                }
            }
            
            /// <summary>
            /// Leptetomezok inicializalasa.
            /// </summary>
            private void LM_Inicializalas()
            {
                Dictionary<Int32, Int32> elemek = new Dictionary<Int32, Int32>();
                elemek.Add(10, 5);
                elemek.Add(11, -1);
                elemek.Add(12, 2);
                elemek.Add(19, 3);
                elemek.Add(20, 2);
                elemek.Add(21, -1);
                elemek.Add(23, -1);
                elemek.Add(27, 1);
                elemek.Add(28, -1);
                elemek.Add(33, 8);
                elemek.Add(37, 2);
                elemek.Add(39, -1);
                
                foreach (KeyValuePair<Int32, Int32> par in elemek)
                {
                    String leiras;
                    _leirasok.TryGetValue(par.Key, out leiras);
                    _mezok[par.Key] = new LeptetoMezo(par.Key, leiras, par.Value, par.Value == -1);
                }
            }

            /// <summary>
            /// Specialismezok inicializalasa.
            /// </summary>
            private void SM_Inicializalas()
            {
                Int32 i = 5;
                String leiras;
                _leirasok.TryGetValue(i, out leiras);
                _mezok[i] = new SpecialisMezo(i, leiras);
                i = 30;
                _leirasok.TryGetValue(i, out leiras);
                _mezok[i] = new SpecialisMezo(i, leiras);
            }

            /// <summary>
            /// Az aktualis jatekos lepeset elvegzo eljaras.
            /// </summary>
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