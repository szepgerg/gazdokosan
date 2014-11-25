using System;
using System.Collections.Generic;
using System.Linq;

namespace GazdOkosan.Model
{
    public class Tabla
    {
        #region Adattagok
            private Mezo[] _mezok;
            private Dictionary<Int32, String> _leirasok;
            private Dictionary<Int32, Dictionary<String, Int32>> _listak;
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
                _mezok = new Mezo[40]; //(1..39)
                Leiras_Inicializalas();
                Lista_Inicializalas();
                TM_Inicializalas();
                SZM_Inicializalas();
                LM_Inicializalas();
                SM_Inicializalas();
                /*foreach (Mezo mezo in _mezok)
                {
                    // Ez a kapcsolat mukodik, 22-es mezore tesztelve. 
                    // Azert van kiveve, mert jelenleg nincs minden mezo peldanyositva.
                    mezo.KartyaHuzas += new EventHandler<EventArgs>(KartyahuzasEsemeny);
                    mezo.Dobas += new EventHandler<EventArgs>(DobasEsemeny);
                    mezo.Lepes += new EventHandler<MezoArgumentumok>(LepesEsemeny);
                }*/

                // Kartyak inicializalasa.
                // !!!!!!!!!!

                // Jatekosok inicializalasa.
                _jatekosSzam = nevek.Length;
                _jatekosok = new Jatekos[_jatekosSzam + 1];
                for (Int32 i = 0; i < _jatekosSzam; ++i)
                {
                    _jatekosok[i+1] = new Jatekos(nevek[i], szinek[i], osszeg);
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
                _leirasok.Add(1, "Szemeteltél, fizess 50,-Ft bűntetést!");
                _leirasok.Add(6, "A dohányzás káros, mert a cigaretta lassan ölő méreg. Hogy jobban eszedbe vésd, fizess 100,-Ft-ot!");
                _leirasok.Add(24, "Az olvasás szórakoztató és hasznos időtöltés. Vegyél könyvutalványt!");
                _leirasok.Add(25, "A Vidám Parkban szórakoztál, elköltöttél 200,-Ft-ot!");
                _leirasok.Add(36, "Sétáltál a Várban és megnézted a Nemzeti Galéria kiállításait. Múzeumi katalógust és képeslapokat vásároltál, fizess 50,-Ft-ot!");
                _leirasok.Add(38, "Egyszerre vásároltad meg alapvető havi élelmiszer-szükségleteidet, fizess 800,-Ft-ot!");
                _leirasok.Add(32, "Kerékpártúrán elsőnek érkeztél célba, jó helyezésedért 1000,-Ft jutalomban részesülsz!");
                _leirasok.Add(3, "Takarékoskodj! Betéteid után az OTP 5% kamatot fizet, amelyet készpénzben a pénztáros ad át!");
                _leirasok.Add(16, "Ha kötöttél CSÉB-biztosítást, a kötvény ellenében vedd át a pénztárostól a biztosítási összeget, 5000,-Ft-ot!");
                _leirasok.Add(4, "Televíziót, rádiót és elektromos háztartási gépet vásárolhatsz!");
                _leirasok.Add(34, "Szaküzletben is vásárolhatsz elektromos háztartási gépeket!");
                _leirasok.Add(7, "Az áruházak osztályain lakásod minden berendezését megvásárolhatod, sőt sportfelszereléseket is vehetsz!");
                _leirasok.Add(13, "Lakásodat most teljesen berendezheted!");
                _leirasok.Add(8, "Légy erőlelátó! Köss lakásbiztosítást és megkötheted a CSÉB-biztosítást is!");
                _leirasok.Add(17, "Ha nincs televíziód, rádiód és háztartási géped - kölcsönözhetsz is!");
                _leirasok.Add(18, "Szórakozni szeretnél. Vásárolj színház-, vagy mozijegyet!");
                _leirasok.Add(29, "Itt megvásárolhatod a szükséges bútorokat és sportfelszereléseket!");
                // !!!!!!!!!! 14,26
            }

            public void Lista_Inicializalas()
            {
                // ////////// Igy lehet megindexelni a Dictionary-t.
                //int n = 3; (4.elem)
                //int nthValue = lista[lista.Keys.ToList()[n]];
                // //////////
                _listak = new Dictionary<Int32, Dictionary<String, Int32>>();
                Dictionary<String, Int32> lista = new Dictionary<String, Int32>();

                lista.Clear();
                lista.Add("Televízió", 6000);
                lista.Add("Rádió", 2000);
                lista.Add("Porszívó", 1000);
                lista.Add("Hűtőgép", 4000);
                lista.Add("Mosógép", 5000);
                _listak.Add(4, lista);
                _listak.Add(34, lista);

                lista.Clear();
                lista.Add("Szobabútor", 25000);
                lista.Add("Konyhabútor", 15000);
                lista.Add("Hűtőgép", 4000);
                lista.Add("Mosógép", 5000);
                lista.Add("Pingpongasztal", 2000);
                lista.Add("Porszívó", 1000);
                lista.Add("Televízió", 6000);
                lista.Add("Rádió", 2000);
                lista.Add("Kerékpár", 1500);
                _listak.Add(7, lista);
                _listak.Add(13, lista);

                lista.Clear();
                lista.Add("Televízió", 500);
                lista.Add("Rádió", 200);
                lista.Add("Mosógép", 500);
                _listak.Add(17, lista);

                lista.Clear();
                lista.Add("Lakásbiztosítás", 200);
                lista.Add("CSÉB-biztosítás", 150);
                _listak.Add(8, lista);

                lista.Clear();
                lista.Add("Színházjegy", 100);
                lista.Add("Mozijegy", 50);
                _listak.Add(18, lista);

                lista.Clear(); 
                lista.Add("Szobabútor", 25000);
                lista.Add("Konyhabútor", 15000);
                lista.Add("Pingpongasztal", 2000);
                lista.Add("Kerékpár", 1500);
                _listak.Add(29, lista);
            }

            /// <summary>
            /// Tranzakcios mezok inicializalasa.
            /// </summary>
            private void TM_Inicializalas()
            {
                TranzakciosMezo.Tipus t = new TranzakciosMezo.Tipus();
                String leiras;

                t = TranzakciosMezo.Tipus.Egyszeru;
                Dictionary<Int32, Int32> elemek = new Dictionary<Int32, Int32>();
                elemek.Add(1, 50);
                elemek.Add(6, 100);
                elemek.Add(24, 200);
                elemek.Add(25, 200);
                elemek.Add(36, 50);
                elemek.Add(38, 800);
                elemek.Add(32, -1000);
                foreach (KeyValuePair<Int32, Int32> par in elemek)
                {
                    _leirasok.TryGetValue(par.Key, out leiras);
                    _mezok[par.Key] = new TranzakciosMezo(par.Key, leiras, t, par.Value);
                }

                t = TranzakciosMezo.Tipus.Felteteles;
                Int32 e = 3;
                _leirasok.TryGetValue(i, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);
                e = 16;
                _leirasok.TryGetValue(i, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);

                t = TranzakciosMezo.Tipus.Listas;
                Int32[] listasElemek = new Int32[8] { 4, 34, 7, 13, 8, 17, 18, 29 };
                for (Int32 i = 0; i < listasElemek.Length; ++i)
                {
                    _leirasok.TryGetValue(listasElemek[i], out leiras);
                    Dictionary<String, Int32> lista;
                    _listak.TryGetValue(listasElemek[i], out lista);
                    _mezok[elemek[i]] = new TranzakciosMezo(listasElemek[i], leiras, t, -1, lista);
                }
            }

            /// <summary>
            /// Szerencse mezok inicializalasa.
            /// </summary>
            private void SZM_Inicializalas()
            {
                Int32[] elemek = new Int32[6]{2, 9, 15, 22, 31, 35};
                for (Int32 i = 0; i < elemek.Length; ++i )
                {
                    String leiras;
                    _leirasok.TryGetValue(elemek[i], out leiras);
                    _mezok[elemek[i]] = new SzerencseMezo(elemek[i], leiras);
                }
            }
            
            /// <summary>
            /// Lepteto mezok inicializalasa.
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
            /// Specialis mezok inicializalasa.
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
            /// A mezo dobast jelzo esemenyenek kezelese.
            /// </summary>
            /// <param name="sender"> Az esemenyt kivalto mezo. </param>
            /// <param name="e"> Az esemeny parameterei. </param>
            public void DobasEsemeny(object sender, EventArgs e)
            {
                Dobas();
            }

            /// <summary>
            /// Az aktualis jatekos lepeset elvegzo eljaras.
            /// </summary>
            public void Dobas()
            {
                // Dobas.
                Random rand = new Random();
                Int32 dobas = rand.Next(1, 7);

                Lepes(dobas);
            }

            /// <summary>
            /// A mezo lepest jelzo esemenyenek kezelese.
            /// </summary>
            /// <param name="sender"> Az esemenyt kivalto mezo. </param>
            /// <param name="e"> Az esemeny parameterei(lepesszam). </param>
            public void LepesEsemeny(object sender, MezoArgumentumok e)
            {
                Lepes(e.Lepesszam);
            }

            /// <summary>
            /// A jatekos leptetese.
            /// </summary>
            /// <param name="dobas"> Dobas eredmenye, ennyit lep a jatekos. </param>
            public void Lepes(Int32 dobas)
            {
                // A kovetkezo pozicio meghatarozasa.
                Int32 poz = (_jatekosok[_kovJatekos].Pozicio + dobas) % 39 + 1;

                // A jatekos uj mezoje elvegzi a szukseges valtozasokat a jatekoson.
                // !!!!!!!!!!
                // Megvalositani minden mezore a Kezel(Jatekos) metodust.
                _mezok[poz].Kezel(_jatekosok[_kovJatekos]);
                
                // Kovetkezo jatekos beallitasa.
                // !!!!!!!!!!
                // Ha kimarad/ketszer jon(otlet legyen esemenyhez kotve, amit a mezo nem mindig valt ki).
                JatekosValtas();
            }

            /// <summary>
            /// A jatekosok ciklikus valtogatasat elvegzo metodus.
            /// </summary>
            public void JatekosValtas()
            {
                _kovJatekos = (_kovJatekos + 1) % 4 + 1;
            }

            /// <summary>
            /// A mezo karatyahuzast jelzo esemenyenek kezelese.
            /// </summary>
            /// <param name="sender"> Az esemenyt kivalto mezo. </param>
            /// <param name="e"> Az esemeny parameterei. </param>
            public void KartyahuzasEsemeny(object sender, EventArgs e)
            {
                Kartyahuzas();
            }

            /// <summary>
            /// A szerencsekartya huzasat tamogato metodus.
            /// </summary>
            public void Kartyahuzas()
            { 
                // !!!!!!!!!!
            }
        #endregion
    }
}