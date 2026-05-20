using ritaripeli;

internal class Ritaripeli
{
    private Ritari ritari;
    private IKauppa nuolikauppa;
    private IKauppa ravintola;

    public Ritaripeli()
    {
        ritari = new Ritari(10, 10);          // 10 HP, 10 kultaa
        nuolikauppa = new Nuolikauppa();
        ravintola = new Ravintola();
    }

    private void NuolikauppaTila()
    {
        bool jatka = true;

        while (jatka)
        {
            Print.Line("Tervetuloa nuolikauppaan!");
            Print.Line("Valitse toiminto:");
            Print.Line("1 Osta mittatilausnuoli");
            Print.Line("2 Listaa kaupan tavarat");
            Print.Line("3 Osta tavara");
            Print.Line("4 Poistu");
            Print.Write("> ");

            string? valinta = Console.ReadLine();

            switch (valinta)
            {
                case "1":
                    Print.Line("Mittatilausnuoli maksaa 5 kultarahaa.");
                    if (ritari.Rahapussi.OtaRahaa(5) > 0)
                    {
                        ritari.Reppu.LisaaTavara(new Nuoli("Perusnuoli",3)); // 3 vahinkoa
                        Print.Line("Ostit mittatilausnuolen!");
                    }
                    else
                    {
                        Print.Line("Sinulla ei ole tarpeeksi rahaa.");
                    }
                    break;

                case "2":
                    ListaaKaupanTavarat(nuolikauppa);
                    break;

                case "3":
                    OstaKaupasta(nuolikauppa);
                    break;

                case "4":
                    jatka = false;
                    break;

                default:
                    Print.Line("Virheellinen valinta.");
                    break;
            }
        }
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
            Print.Line("Tilanne: Sinulla on " +
                       $"{ritari.Osumapisteet} osumapistettä ja {ritari.Rahapussi.Rahat} kultarahaa.");
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
                    NuolikauppaTila();
                    break;
                case "2":
                    RavintolaTila();
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
    private void RavintolaTila()
    {
        bool jatka = true;

        while (jatka)
        {
            Print.Line("Tervetuloa ravintolaan!");
            Print.Line("Valitse toiminto:");
            Print.Line("1 Osta pieni ateria (2 HP, 3 kr)");
            Print.Line("2 Osta iso ateria (5 HP, 6 kr)");
            Print.Line("3 Poistu");
            Print.Write("> ");

            string? valinta = Console.ReadLine();

            switch (valinta)
            {
                case "1":
                    if (ritari.Rahapussi.OtaRahaa(3) > 0)
                    {
                        ritari.Reppu.LisaaTavara(new Ruoka("Pieni ateria", 2));
                        Print.Line("Ostit pienen aterian.");
                    }
                    else
                    {
                        Print.Line("Ei tarpeeksi rahaa.");
                    }
                    break;

                case "2":
                    if (ritari.Rahapussi.OtaRahaa(6) > 0)
                    {
                        ritari.Reppu.LisaaTavara(new Ruoka("Iso ateria", 5));
                        Print.Line("Ostit ison aterian.");
                    }
                    else
                    {
                        Print.Line("Ei tarpeeksi rahaa.");
                    }
                    break;

                case "3":
                    jatka = false;
                    break;

                default:
                    Print.Line("Virheellinen valinta.");
                    break;
            }
        }
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

                    if (esine is Ruoka ruoka)
                    {
                        ritari.OtaVahinkoa(-ruoka.Parannus);
                        ritari.Reppu.PoistaTavara(esine);
                        Print.Line($"Käytit esineen {ruoka.Nimi}. HP nyt {ritari.Osumapisteet}.");
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
    }

}