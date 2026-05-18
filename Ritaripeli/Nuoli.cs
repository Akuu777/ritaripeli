namespace Ritaripeli
{
    public enum Karki { Puu, Teräs, Timantti }
    public enum Pera { Lehti, Kanansulka, Kotkansulka }

    public class Nuoli : ITavara
    {
        public Karki Karki { get; }
        public Pera Pera { get; }
        public int Pituus { get; }

        public string Nimi => $"{Karki} / {Pera} nuoli";
        public int Hinta => (int)LaskeHinta();

        public Nuoli(Karki karki, Pera pera, int pituus)
        {
            Karki = karki;
            Pera = pera;
            Pituus = pituus;
        }

        public static Nuoli LuoEliittiNuoli() =>
            new Nuoli(Karki.Timantti, Pera.Kotkansulka, 100);

        public static Nuoli LuoAloittelijaNuoli() =>
            new Nuoli(Karki.Puu, Pera.Kanansulka, 70);

        public static Nuoli LuoPerusNuoli() =>
            new Nuoli(Karki.Teräs, Pera.Kanansulka, 85);

        private double LaskeHinta()
        {
            double hinta = 0;

            if (Karki == Karki.Puu) hinta += 3;
            if (Karki == Karki.Teräs) hinta += 5;
            if (Karki == Karki.Timantti) hinta += 50;

            if (Pera == Pera.Lehti) hinta += 0;
            if (Pera == Pera.Kanansulka) hinta += 1;
            if (Pera == Pera.Kotkansulka) hinta += 5;

            hinta += Pituus * 0.05;

            return hinta;
        }
    }
}