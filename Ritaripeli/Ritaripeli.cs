using ritaripeli;

internal class Ritaripeli
{
    private List<Hirviö> hirviot = new List<Hirviö>()
    {
        new Susi(),
        new Lohikaarme(),
        new Peikko()
    };

    private Ritari ritari;
    private IKauppa nuolikauppa;
    private IKauppa ravintola;

    public Ritaripeli()
    {
        ritari = new Ritari(10, 10);
        nuolikauppa = new Nuolikauppa();
        ravintola = new Ravintola();
    }

    private void ListaaKaupanTavarat(IKauppa kauppa)
    {
        List<TavaraJaHinta> tavarat = kauppa.ListaaTavarat();

        Print.Line("Kaupan tavarat:");
        for (int i = 0; i < tavarat.Count; i++)
        {
            Print.Line($"{i + 1}: {tavarat[i].Esine.Nimi}  {tavarat[i].Hinta} kr");
        }
    }

    private void OstaKaupasta(IKauppa kauppa)
    {
        ListaaKaupanTavarat(kauppa);

        Print.Line("Minkä tavaran haluat ostaa?");
        Print.Write("> ");

        string syote = Console.ReadLine();
        int valinta;

        if (int.TryParse(syote, out valinta))
        {
            Tavara ostettu = kauppa.OstaTavara(valinta - 1, ritari.Rahapussi);

            if (ostettu != null)
            {
                ritari.Reppu.LisaaTavara(ostettu);
                Print.LineColor($"Ostit tavaran {ostettu.Nimi}.", ConsoleColor.Green);
            }
            else
            {
                Print.LineColor("Osto epäonnistui.", ConsoleColor.Red);
            }
        }
    }

    public void Kaynnista()
    {
        bool jatka = true;

        while (jatka && ritari.Osumapisteet > 0)
        {
            if (ritari.Voitot >= 3)
            {
                Print.LineColor("Olet voittanut 3 hirviötä! Voitit pelin!", ConsoleColor.Green);
                return;
            }

            if (ritari.Rahapussi.Rahat >= 30)
            {
                Print.LineColor("Olet kerännyt 30 kultarahaa! Voitit pelin!", ConsoleColor.Green);
                return;
            }

            Print.Line($"Tilanne: {ritari.Osumapisteet} HP, {ritari.Rahapussi.Rahat} kr");
            Print.Line("Valitse toiminto:");
            Print.Line("1 Mene nuolikauppaan");
            Print.Line("2 Mene ravintolaan");
            Print.Line("3 Lähde taisteluun");
            Print.Line("4 Käytä repussa olevia esineitä");
            Print.Line("5 Lopeta");
            Print.Write("> ");

            string valinta = Console.ReadLine();

            switch (valinta)
            {
                case "1":
                    OstaKaupasta(nuolikauppa);
                    break;

                case "2":
                    OstaKaupasta(ravintola);
                    break;

                case "3":
                    TaisteluTila();
                    break;

                case "4":
                    ReppuTila();
                    break;

                case "5":
                    jatka = false;
                    break;

                default:
                    Print.LineColor("Virheellinen valinta.", ConsoleColor.Red);
                    break;
            }
        }

        Print.LineColor("Peli päättyi.", ConsoleColor.Red);
    }

    private void ReppuTila()
    {
        bool jatka = true;

        while (jatka)
        {
            Print.Line("Reppu:");
            ritari.Reppu.Listaa();

            Print.Line("Valitse esineen numero käyttääksesi sitä tai 0 poistuaksesi.");
            Print.Write("> ");

            string syote = Console.ReadLine();
            int valinta;

            if (int.TryParse(syote, out valinta))
            {
                if (valinta == 0)
                {
                    jatka = false;
                    continue;
                }

                IReadOnlyList<Tavara> tavarat = ritari.Reppu.Tavarat;

                if (valinta > 0 && valinta <= tavarat.Count)
                {
                    Tavara esine = tavarat[valinta - 1];

                    if (esine is Ruoka ruoka)
                    {
                        ritari.OtaVahinkoa(-ruoka.Parannus);
                        ritari.Reppu.PoistaTavara(esine);
                        Print.LineColor($"Käytit {ruoka.Nimi}. HP nyt {ritari.Osumapisteet}.", ConsoleColor.Green);
                    }
                    else if (esine is Nuoli nuoli)
                    {
                        Print.LineColor($"{nuoli.Nimi} ei tee mitään repussa. Käytä taistelussa!", ConsoleColor.DarkGray);
                    }
                    else if (esine is Miekka miekka)
                    {
                        ritari.Ase = miekka;
                        ritari.Reppu.PoistaTavara(esine);
                        Print.LineColor($"Vaihdoit aseeksi: {miekka.Nimi}", ConsoleColor.Green);
                    }
                    else
                    {
                        Print.LineColor("Tätä esinettä ei voi käyttää.", ConsoleColor.Red);
                    }
                }
                else
                {
                    Print.LineColor("Virheellinen valinta.", ConsoleColor.Red);
                }
            }
            else
            {
                Print.LineColor("Virheellinen syöte.", ConsoleColor.Red);
            }
        }
    }

    private void TaisteluTila()
    {
        Random rng = new Random();
        Hirviö hirvio = hirviot[rng.Next(hirviot.Count)];

        Print.LineColor("Kohtaat hirviön: " + hirvio.Nimi + "!", ConsoleColor.Yellow);

        while (hirvio.Osumapisteet > 0 && ritari.Osumapisteet > 0)
        {
            Print.Line($"Oma op ({ritari.Osumapisteet})  Vihollinen ({hirvio.Osumapisteet})");
            Print.Line("1 Hyökkää");
            Print.Line("2 Käytä esinettä");
            Print.Line("3 Pakene");
            Print.Write("> ");

            string valinta = Console.ReadLine();

            if (valinta == "1")
            {
                int dmg = ritari.Ase.Vahinko;
                hirvio.OtaVahinkoa(dmg);
                Print.LineColor($"{ritari.Ase.Nimi} aiheutti {dmg} vahinkoa.", ConsoleColor.Green);

                if (hirvio.Osumapisteet > 0)
                {
                    int hv = hirvio.AnnaVahinko();
                    ritari.OtaVahinkoa(hv);
                    Print.LineColor($"{hirvio.Nimi} lyö sinua ja aiheuttaa {hv} vahinkoa.", ConsoleColor.Red);
                }
            }
            else if (valinta == "2")
            {
                Print.Line("Valitse esine:");
                ritari.Reppu.Listaa();
                Print.Write("> ");

                string esineSyote = Console.ReadLine();
                int esineValinta;

                if (int.TryParse(esineSyote, out esineValinta))
                {
                    if (esineValinta > 0 && esineValinta <= ritari.Reppu.Tavarat.Count)
                    {
                        Tavara esine = ritari.Reppu.Tavarat[esineValinta - 1];

                        if (esine is Ruoka r)
                        {
                            ritari.OtaVahinkoa(-r.Parannus);
                            ritari.Reppu.PoistaTavara(esine);
                            Print.LineColor($"Söit {r.Nimi} ja parannuit {r.Parannus}.", ConsoleColor.Green);
                        }
                        else if (esine is Nuoli n)
                        {
                            hirvio.OtaVahinkoa(n.Vahinko);
                            ritari.Reppu.PoistaTavara(esine);
                            Print.LineColor($"{n.Nimi} aiheutti {n.Vahinko} vahinkoa.", ConsoleColor.Green);
                        }
                        else if (esine is Miekka m)
                        {
                            ritari.Ase = m;
                            Print.LineColor($"Vaihdoit aseeksi: {m.Nimi}", ConsoleColor.Green);
                        }
                    }
                }

                if (hirvio.Osumapisteet > 0)
                {
                    int hv = hirvio.AnnaVahinko();
                    ritari.OtaVahinkoa(hv);
                    Print.LineColor($"{hirvio.Nimi} lyö sinua ja aiheuttaa {hv} vahinkoa.", ConsoleColor.Red);
                }
            }
            else if (valinta == "3")
            {
                Print.LineColor("Pakenit taistelusta.", ConsoleColor.DarkGray);
                return;
            }
            else
            {
                Print.LineColor("Virheellinen valinta.", ConsoleColor.Red);
            }
        }

        if (ritari.Osumapisteet <= 0)
        {
            Print.LineColor("Hirviö voitti sinut.", ConsoleColor.Red);
            return;
        }

        Print.LineColor($"Voitit hirviön: {hirvio.Nimi}!", ConsoleColor.Green);
        ritari.Rahapussi.LisaaRahaa(hirvio.KultaPalkinto);
        Print.LineColor($"Saat {hirvio.KultaPalkinto} kultarahaa.", ConsoleColor.Yellow);
        ritari.Voitot++;
    }
}