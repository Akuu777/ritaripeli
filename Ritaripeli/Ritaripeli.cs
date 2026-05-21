using ritaripeli;

internal class Ritaripeli
{
    private List<Hirviö> hirviot = new()
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
        var tavarat = kauppa.ListaaTavarat();

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

        if (int.TryParse(Console.ReadLine(), out int valinta))
        {
            var ostettu = kauppa.OstaTavara(valinta - 1, ritari.Rahapussi);

            if (ostettu != null)
            {
                ritari.Reppu.LisaaTavara(ostettu);
                Print.Line($"Ostit tavaran {ostettu.Nimi}.");
            }
            else
            {
                Print.Line("Osto epäonnistui.");
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
                Print.Line("Olet voittanut 3 hirviötä! Voitit pelin!");
                return;
            }

            if (ritari.Rahapussi.Rahat >= 30)
            {
                Print.Line("Olet kerännyt 30 kultarahaa! Voitit pelin!");
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

            string? valinta = Console.ReadLine();

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
                    Print.Line("Virheellinen valinta.");
                    break;
            }
        }

        Print.Line("Peli päättyi.");
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

            string? syote = Console.ReadLine();

            if (int.TryParse(syote, out int valinta))
            {
                if (valinta == 0)
                {
                    jatka = false;
                    continue;
                }

                var tavarat = ritari.Reppu.Tavarat;

                if (valinta > 0 && valinta <= tavarat.Count)
                {
                    var esine = tavarat[valinta - 1];

                    // RUOKA
                    if (esine is Ruoka ruoka)
                    {
                        ritari.OtaVahinkoa(-ruoka.Parannus);
                        ritari.Reppu.PoistaTavara(esine);
                        Print.Line($"Käytit esineen {ruoka.Nimi}. HP nyt {ritari.Osumapisteet}.");
                    }
                    else if (esine is Nuoli nuoli)
                    {
                        Print.Line($"{nuoli.Nimi} ei tee mitään repussa. Käytä taistelussa!");
                    }
                    else if (esine is Miekka miekka)
                    {
                        ritari.Ase = miekka;
                        ritari.Reppu.PoistaTavara(esine);
                        Print.Line($"Vaihdoit aseeksi: {miekka.Nimi}");
                    }

                    else
                    {
                        Print.Line("Tätä esinettä ei voi käyttää.");
                    }
                }
                else
                {
                    Print.Line("Virheellinen valinta.");
                }
            }
            else
            {
                Print.Line("Virheellinen syöte.");
            }
        }
    }


    private void TaisteluTila()
    {
        Random rng = new Random();
        Hirviö hirvio = hirviot[rng.Next(hirviot.Count)];

        Print.Line("Kohtaat hirviön: " + hirvio.Nimi + "!");

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
                Print.Line($"{ritari.Ase.Nimi} aiheutti {dmg} vahinkoa.");

                if (hirvio.Osumapisteet > 0)
                {
                    int hv = hirvio.AnnaVahinko();
                    ritari.OtaVahinkoa(hv);
                    Print.Line($"{hirvio.Nimi} lyö sinua ja aiheuttaa {hv} vahinkoa.");
                }
            }
            else if (valinta == "2")
            {
                Print.Line("Valitse esine:");
                ritari.Reppu.Listaa();
                Print.Write("> ");

                if (int.TryParse(Console.ReadLine(), out int esineValinta))
                {
                    if (esineValinta > 0 && esineValinta <= ritari.Reppu.Tavarat.Count)
                    {
                        Tavara esine = ritari.Reppu.Tavarat[esineValinta - 1];

                        if (esine is Ruoka r)
                        {
                            ritari.OtaVahinkoa(-r.Parannus);
                            ritari.Reppu.PoistaTavara(esine);
                            Print.Line($"Söit {r.Nimi} ja parannuit {r.Parannus}.");
                        }
                        else if (esine is Nuoli n)
                        {
                            hirvio.OtaVahinkoa(n.Vahinko);
                            ritari.Reppu.PoistaTavara(esine);
                            Print.Line($"{n.Nimi} aiheutti {n.Vahinko} vahinkoa.");
                        }
                        else if (esine is Miekka m)
                        {
                            ritari.Ase = m;
                            Print.Line($"Vaihdoit aseeksi: {m.Nimi}");
                        }
                    }
                }

                if (hirvio.Osumapisteet > 0)
                {
                    int hv = hirvio.AnnaVahinko();
                    ritari.OtaVahinkoa(hv);
                    Print.Line($"{hirvio.Nimi} lyö sinua ja aiheuttaa {hv} vahinkoa.");
                }
            }
            else if (valinta == "3")
            {
                Print.Line("Pakenit taistelusta.");
                return;
            }
            else
            {
                Print.Line("Virheellinen valinta.");
            }
        }

        if (ritari.Osumapisteet <= 0)
        {
            Print.Line("Hirviö voitti sinut.");
            return;
        }

        Print.Line($"Voitit hirviön: {hirvio.Nimi}!");
        ritari.Rahapussi.LisaaRahaa(hirvio.KultaPalkinto);
        Print.Line($"Saat {hirvio.KultaPalkinto} kultarahaa.");
        ritari.Voitot++;
    }
}
