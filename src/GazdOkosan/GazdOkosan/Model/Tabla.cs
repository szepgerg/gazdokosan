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
            private List<Kartya> _kartyak;
            private Jatekos[] _jatekosok;
            private Int32 _jatekosSzam;
            private Int32 _kovJatekos;
            private Int32 _dobas;
            private Int32 _egyVagyHatJatekos;

            private Kartya szerencseKartya;
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
                foreach (Mezo mezo in _mezok)
                {
                    // !!!!!!!!!!
                    if(mezo != null)
                    {
                        mezo.KartyaHuzas += new EventHandler<EventArgs>(KartyahuzasEsemeny);
                        mezo.Dobas += new EventHandler<EventArgs>(DobasEsemeny);
                        mezo.Lepes += new EventHandler<MezoArgumentumok>(LepesEsemeny);
                        mezo.EgyVagyHatJatekos += new EventHandler<EventArgs>(EgyVagyHatJatekosEsemeny);
                    }
                }

                // Kartyak inicializalasa.
                Kartya_Inicializalas();

                // Jatekosok inicializalasa.
                _jatekosSzam = nevek.Length;
                _jatekosok = new Jatekos[_jatekosSzam + 1];
                for (Int32 i = 0; i < _jatekosSzam; ++i)
                {
                    _jatekosok[i+1] = new Jatekos(nevek[i], szinek[i], osszeg);
                }

                _kovJatekos = 1;

                // //////////
                _jatekosok[_kovJatekos].Pozicio = 28;
                Dobas();
                // //////////
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
                _leirasok.Add(14, "Szövetkezeti lakásépítés! Ha van már elegendő pénzed, fizess be a pénztárnak 30000,-Ft-ot és a hátralevő 40000,-Ft-ot körönként 2000,-Ft-os részletekben törlesztheted!");
                _leirasok.Add(26, "Vegyél részt társasház-építésben! Ha van már elegendő pénzed, fizess be a pénztárnak 30000,-Ft-ot és a hátralevő 40000,-Ft-ot körönként 2000,-Ft-os részletekben törlesztheted!");
            }

            /// <summary>
            /// A vasarlasi listak inicializalasa.
            /// </summary>
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
                lista.Add("Szobabútor", 25000);     //Szobabútor - 1
                lista.Add("Konyhabútor", 15000);    //Konyhabútor - 2
                lista.Add("Hűtőgép", 4000);         //Hűtőgép - 3
                lista.Add("Mosógép", 5000);         //Mosógép - 4
                lista.Add("Pingpongasztal", 2000);  //Pingpongasztal - 5
                lista.Add("Porszívó", 1000);        //Porszívó - 6
                lista.Add("Televízió", 6000);       //Televízió - 7
                lista.Add("Rádió", 2000);           //Radió - 8
                lista.Add("Kerékpár", 1500);        //Kerékpár - 9
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
                _leirasok.TryGetValue(e, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);
                e = 16;
                _leirasok.TryGetValue(e, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);

                t = TranzakciosMezo.Tipus.Listas;
                Int32[] listasElemek = new Int32[8] { 4, 34, 7, 13, 8, 17, 18, 29 };
                for (Int32 i = 0; i < listasElemek.Length; ++i)
                {
                    _leirasok.TryGetValue(listasElemek[i], out leiras);
                    Dictionary<String, Int32> lista;
                    _listak.TryGetValue(listasElemek[i], out lista);
                    _mezok[listasElemek[i]] = new TranzakciosMezo(listasElemek[i], leiras, t, -1, lista);
                }

                t = TranzakciosMezo.Tipus.Torleszto;
                e = 14;
                _leirasok.TryGetValue(e, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);
                e = 26;
                _leirasok.TryGetValue(e, out leiras);
                _mezok[e] = new TranzakciosMezo(e, leiras, t, -1);
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

            private void Kartya_Inicializalas()
            {
                _kartyak = new List<Kartya>();
                _kartyak.Add(new Kartya("Lépj a 38-as mezőre!", "SETA", 38));
                _kartyak.Add(new Kartya("Szereted a fagyit.Én is.De semmi sincs ingyen!Ezért fizetned kell 250Ft-ot!", "FIZET", -250));
                _kartyak.Add(new Kartya("Vedd fel a fizetésed!", "FIZET", 2000));
                _kartyak.Add(new Kartya("Megnyerted a színes televíziót!", "BUTOR", 7));
                _kartyak.Add(new Kartya("Erre is jó egy könyvelő.Visszaigényelt neked az APEH-től 50.000Ft-ot", "FIZET", 50000));
                _kartyak.Add(new Kartya("Kisöcséted meghívtad egy fagylaltra.250Ft-ot fizettél!", "FIZET", 250));
                _kartyak.Add(new Kartya("Megnyerted a szobabútorokat", "BUTOR", 1));
                _kartyak.Add(new Kartya("Lépj a 21-as mezőre!", "SETA", 21));
                _kartyak.Add(new Kartya("De rendes vagy!Adományoztál 5000Ft-ot", "FIZET", -5000));
                _kartyak.Add(new Kartya("Lépj a 38-as mezőre!", "SETA", 38));
                _kartyak.Add(new Kartya("Nyertél egy hűtőszekrényt", "BUTOR", 3));
                _kartyak.Add(new Kartya("Újra húzhatsz!", "KARTYA", 1));
                _kartyak.Add(new Kartya("Nyertél 100.000Ft-ot!", "FIZET", 100000));
                _kartyak.Add(new Kartya("Nyertél egy 100.000Ft-os kötvényt", "KOTVENY", 100000));
                _kartyak.Add(new Kartya("Innen lépj át a 22-es mezőre", "SETA", 22));
                _kartyak.Add(new Kartya("Reklám nélkül nem fog beindulni a céged!15.000Ft reklámköltésget kell fizetned", "FIZET", -15000));
                _kartyak.Add(new Kartya("Nyertél egy 50.000Ft-os kötvényt", "KOTVENY", 50000));
                _kartyak.Add(new Kartya("Megnyerted a konyhabútort", "BUTOR", 2));
                _kartyak.Add(new Kartya("Kötvényeid árfolyama 50%-kal emelkedett", "KOTVENY_SZORZAS", 50));
                _kartyak.Add(new Kartya("Születésnapodra szüleid nem tudták, hogy mit vegyenek neked, ezért 10.000Ft-ot kaptál", "FIZET", 10000));
                _kartyak.Add(new Kartya("Nyertél 50.000Ft-ot", "FIZET", 50000));
                _kartyak.Add(new Kartya("Megnyerted a rádiót", "BUTOR", 8));
                _kartyak.Add(new Kartya("Fűtés számla: 5.000Ft", "FIZET", -5000));
                _kartyak.Add(new Kartya("Közlekedési kihágásért a rendőr megbüntetett 1.000Ft-ra!", "FIZET", -1000));
                _kartyak.Add(new Kartya("Sorsoláson 50.000Ft-os kötvényt nyertél", "KOTVENY", 50000));
                _kartyak.Add(new Kartya("Vissza nem térítendő kölcsönt kaptál a banktól 50.000Ft értékben", "FIZET", 50000));
                _kartyak.Add(new Kartya("Lépj a 2-es mezőre!", "SETA", 2));
                _kartyak.Add(new Kartya("Nyertél egy kerékpárt", "BUTOR", 9));
                _kartyak.Add(new Kartya("Ki kell fizetned a fűtésszámládat, értéke: 5.000Ft", "FIZET", -5000));
                _kartyak.Add(new Kartya("Szerencsjátékon nyertél egy 100.000-os kötvényt!", "KOTVENY", 100000));
                _kartyak.Add(new Kartya("Megnyerted a mosógépet", "BUTOR", 4));
                _kartyak.Add(new Kartya("Lottón nyertél 100.000Ft-ot!", "FIZET", 100000));
                _kartyak.Add(new Kartya("Piroson mentél át ezért a rendőr megbüntetett 1.000Ft-ra!", "FIZET", 1000));
                _kartyak.Add(new Kartya("50.000Ft-ot nyertél!", "FIZET", 50000));
                _kartyak.Add(new Kartya("Megnyerted a hűtőszekrényt!", "BUTOR", 3));
                _kartyak.Add(new Kartya("Újra húzhatsz!", "KARTYA", 1));
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
                Random rand = new Random();
                    _dobas = rand.Next(1, 7);   
                Lepes();
            }

            /// <summary>
            /// A mezo lepest jelzo esemenyenek kezelese.
            /// </summary>
            /// <param name="sender"> Az esemenyt kivalto mezo. </param>
            /// <param name="e"> Az esemeny parameterei(lepesszam). </param>
            public void LepesEsemeny(object sender, MezoArgumentumok e)
            {
                _dobas = e.Lepesszam;
                Lepes();
            }

            /// <summary>
            /// A jatekos leptetese.
            /// </summary>
            /// <param name="dobas"> Dobas eredmenye, ennyit lep a jatekos. </param>
            public void Lepes()
            {
                if (_kovJatekos == _egyVagyHatJatekos && _dobas != 1 && _dobas != 6)
                {
                    JatekosValtas();
                }
                else if ((_kovJatekos == _egyVagyHatJatekos && (_dobas == 1 || _dobas == 6))
                         || _kovJatekos != _egyVagyHatJatekos) 
                {
                    Int32 poz = _jatekosok[_kovJatekos].Pozicio + _dobas;
                    if (poz > 39) poz = poz - 39;

                    // !!!!!!!!!!
                    // A poz. mezo leirasanak megjelenitese felugro ablakba.
                    // Ha a mezo Tranzakcios.Listas a lista megjelenitese
                    // Kivalasztott ertek indexenek visszaadasa.
                    // Annak megfeleloen mit valaszt, vanTV = true...

                    // Jatekos uj poziciojanak mentese.
                    _jatekosok[_kovJatekos].Pozicio = poz;
                    // Mezore lepes, az uj mezo kezeli a jatekos valtozasait.
                    _mezok[poz].Kezel(_jatekosok[_kovJatekos]);

                    JatekosValtas();
                }
                else if( _kovJatekos == _egyVagyHatJatekos && (_dobas == 1 || _dobas == 6) )
                {
                    _egyVagyHatJatekos = -1;
                }
            }

            /// <summary>
            /// A jatekosok ciklikus valtogatasat elvegzo metodus.
            /// </summary>
            public void JatekosValtas()
            {
                _kovJatekos = (_kovJatekos % 2) + 1;
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
                int szam = new Random().Next(_kartyak.Count());
                szerencseKartya = _kartyak[szam];
                //new KartyaDialog(szerencseKartya.Leiras);

                if(szerencseKartya.Muvelet.Equals("FIZET"))
                {
                    _jatekosok[_kovJatekos].Osszeg += szerencseKartya.Ertek;
                }
                if (szerencseKartya.Muvelet.Equals("KOTVENY"))
                {
                    _jatekosok[_kovJatekos].Takarek += szerencseKartya.Ertek;
                }
                if (szerencseKartya.Muvelet.Equals("KOTVENY_SZORZAS"))
                {
                    double szorzat = szerencseKartya.Ertek / 100;
                    int temp = (int)(_jatekosok[_kovJatekos].Osszeg * szorzat);
                    _jatekosok[_kovJatekos].Takarek += temp;
                }
                if (szerencseKartya.Muvelet.Equals("SETA"))
                {
                    /*
                     * Ha a Játékos aktuiális pozíciója nagyobb mint a kártyán szereplő Mezőszám, akkor körbe kell menni a pályán, azaz
                     * át kell haladni a Starton, tehát meg kell kapni a 2.000Ft-ot ami ott jár.
                     * Majd az új pozícióban le kell kezelni a Mező esetleges feladatait.
                     * */
                    if (_jatekosok[_kovJatekos].Pozicio > szerencseKartya.Ertek)
                    {
                        _jatekosok[_kovJatekos].Osszeg += 4000;
                    }
                    _jatekosok[_kovJatekos].Pozicio = szerencseKartya.Ertek;
                    _mezok[szerencseKartya.Ertek].Kezel(_jatekosok[_kovJatekos]);
                }
                if(szerencseKartya.Muvelet.Equals("BUTOR"))
                {
                    String butor = "";

                    switch(szerencseKartya.Ertek)
                    {
                        case 1: butor = "Szobabútor";
                            break;
                        case 2: butor = "Konyhabútor";
                            break;
                        case 3: butor = "Hűtőgép";
                            break;
                        case 4: butor = "Mosógép";
                            break;
                        case 5: butor = "Pingpongasztal";
                            break;
                        case 6: butor = "Pórszívó";
                            break;
                        case 7: butor = "Televízió";
                            break;
                        case 8: butor = "Rádió";
                            break;
                        case 9: butor = "Kerékpár";
                            break;
                    }

                    if ( !(_jatekosok[_kovJatekos].VanButor(butor)) )
                    {
                        _jatekosok[_kovJatekos].AdButor(butor);
                    }
                }
                if (szerencseKartya.Muvelet.Equals("KARTYA"))
                {
                    Kartyahuzas();
                }
            }

            /// <summary>
            /// A specialis mezo csak 1/6-os dobast elfogado esemeny kezelese.
            /// </summary>
            /// <param name="sender"> Az esemenyt kivalto mezo. </param>
            /// <param name="e"> Az esemeny parameterei. </param>
            public void EgyVagyHatJatekosEsemeny(object sender, EventArgs e)
            {
                _egyVagyHatJatekos = _kovJatekos;
            }

            /// <summary>
            /// Takarekbetetet valto metodus.
            /// </summary>
            /// <param name="osszeg"> A takarekbetet ara. </param>
            public void TakarekbetetModell(Int32 osszeg)
            {
                _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - osszeg;
                _jatekosok[_kovJatekos].Takarek = osszeg;
            }

            /// <summary>
            /// Tartozas torleszteset vegzo metodus.
            /// </summary>
            /// <param name="osszeg"> A torlesztoreszlet. </param>
            public void TorlesztModell(Int32 osszeg)
            {
                _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - osszeg;
                _jatekosok[_kovJatekos].Tartozas = _jatekosok[_kovJatekos].Tartozas - osszeg;
            }

            /// <summary>
            /// Haz vasarlasat vegzo metodus.
            /// </summary>
            public void HazvasarlasModell()
            {
                if (_jatekosok[_kovJatekos].Osszeg >= 70000)
                {
                    _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 70000;
                    _jatekosok[_kovJatekos].VanLakas = true;
                }
            }

            /// <summary>
            /// CSEB biztositas valtasat vegzo metodus.
            /// </summary>
            public void CSEBvaltasModell()
            {
                _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 150;
                _jatekosok[_kovJatekos].VanCSEB = true;
            }

            /// <summary>
            /// Lakasbiztositas valtasat vegzo metodus.
            /// </summary>
            public void LakasbiztvaltasModell()
            {
                _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 200;
                _jatekosok[_kovJatekos].VanLakasbizt = true;
            }

            /// <summary>
            /// Specialis hazvasarlast megvalosito metodus.
            /// </summary>
            public void HazVasarlas14Modell()
            {
                if (_jatekosok[_kovJatekos].Osszeg >= 30000)
                {
                    _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 30000;
                    _jatekosok[_kovJatekos].VanLakas = true;
                    _jatekosok[_kovJatekos].Tartozas = 40000;
                }
            }

            /// <summary>
            /// Specialis hazvasarlast megvalosito metodus.
            /// </summary>
            public void HazVasarlas26Modell()
            {
                if (_jatekosok[_kovJatekos].Osszeg >= 40000)
                {
                    _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 40000;
                    _jatekosok[_kovJatekos].VanLakas = true;
                    _jatekosok[_kovJatekos].Tartozas = 30000;
                }
            }

            /// <summary>
            /// Könyvutalvány vásárlását megvalósító metódus.
            /// </summary>
            public void KonyvutalvanyModell()
            {
                _jatekosok[_kovJatekos].Osszeg = _jatekosok[_kovJatekos].Osszeg - 400;
                _jatekosok[_kovJatekos].VanKonyvut = true;
            }
        #endregion


        #region Teszthez
            public Jatekos[] getJatekos()
            {
                return _jatekosok;
            }

            public List<Kartya> getKartyak
            {
                get { return _kartyak; }
            }

            public Kartya getSzerencseKartya
            {
                get { return szerencseKartya; }
            }
       #endregion
    }
}