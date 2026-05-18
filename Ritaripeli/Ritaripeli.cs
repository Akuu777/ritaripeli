using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritaripeli
{
    internal class Ritaripeli
    {
        Ritari pelaaja;
        List<Hirviö> hirviot;
        List<IKauppa> kaupat;
        public Ritaripeli()
        {
            pelaaja = new Ritari(aloitusOsumapisteet: 10, aloitusRahat: 10);
            hirviot = new List<Hirviö>();
            // TODO luo erilaiset hirviöt
            kaupat = new List<IKauppa>();
            // TODO luo erilaiset kaupat
        }

        public void PeliSilmukka()
        {
            Print.Line("Tervetuloa suureen seikkailuun!");
            while (true)
            {

                // TODO näytä pelaajan tilanne
                Print.WriteColor("Tilanne: Osumapisteitä: ", ConsoleColor.White);
                Print.WriteColor($"{pelaaja.Osumapisteet} op ", ConsoleColor.Green);
                Print.WriteColor("Kultaa: ", ConsoleColor.White);
                Print.LineColor($"{pelaaja.Rahapussi.Rahoja} kr", ConsoleColor.Yellow);
                // TODO anna pelaajan valita meneekö kauppaan vai taistelemaan vai käyttääkö tavaroita Repusta
                string valinta = Console.ReadLine();



                // Tarkista onko peli päättynyt
            }
        }

        public void TaisteluTila()
        {
            // TODO arvo pelaajaa vastaan taisteleva hirviö
            Hirviö vastustaja = null;
            while (vastustaja.Osumapisteet > 0 && pelaaja.Osumapisteet > 0)
            {
                // TODO anna pelaajan valita toiminto:
                // 1. hyökkää : aiheuta vahinkoa hirviölle
                // 2. käytä esinettä ; näytä Repun sisältö ja anna pelaajan valita tavara
                // Jos pelaaja käyttää ruoka-annosta, lisää pelaajan osumapisteitä
                // Jos pelaaja käyttää nuolta, ammu nuoli kohti vihollista
                // Jos pelaaja käyttää jotain muuta tavaraa, toimi valinnan mukaan
                // 3. pakene : poistu TaisteluTilasta

                // TODO Jos hirviöllä on osumapisteitä jäljellä
                // arvo hirviön tekemä vahinko ja vähennä se pelaajan osumapisteistä
            }
            // Kun taistelu loppuu, palaa PeliSilmukkaan
        }

        public void KauppaTila()
        {
            // TODO anna pelaajan valita mihin kauppaan pelaaja menee
            // listaa kaupan tavarat ja anna pelaajan valita minkä hän haluaa
            // yrittää ostaa
            // lisää vaihtoehto jolla pelaaja pääsee pois kaupasta ja Kauppatilasta
        }
    }
}