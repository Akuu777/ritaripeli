namespace Ritaripeli
{
    public enum PaaraakaAine { Nautaa, Kanaa, Kasviksia }
    public enum Lisuke { Perunaa, Riisia, Pastaa }
    public enum Kastike { Pippuri, Chili, Tomaatti, Curry }

    public class RuokaAnnos : ITavara
    {
        public PaaraakaAine PaaraakaAine { get; }
        public Lisuke Lisuke { get; }
        public Kastike Kastike { get; }

        public string Nimi => $"{PaaraakaAine} + {Lisuke} ({Kastike}-kastike)";
        public int Hinta => LaskeHinta();

        // Kuinka paljon HP:ta ruoka palauttaa
        public int ParannusMaara { get; }

        public RuokaAnnos(PaaraakaAine paa, Lisuke lis, Kastike kas)
        {
            PaaraakaAine = paa;
            Lisuke = lis;
            Kastike = kas;

            ParannusMaara = LaskeParannus();
        }

        private int LaskeHinta()
        {
            int hinta = 5;

            if (PaaraakaAine == PaaraakaAine.Nautaa) hinta += 5;
            if (PaaraakaAine == PaaraakaAine.Kanaa) hinta += 3;

            if (Lisuke == Lisuke.Riisia) hinta += 1;
            if (Lisuke == Lisuke.Pastaa) hinta += 2;

            if (Kastike == Kastike.Curry) hinta += 2;
            if (Kastike == Kastike.Chili) hinta += 1;

            return hinta;
        }

        private int LaskeParannus()
        {
            int hp = 3;

            if (PaaraakaAine == PaaraakaAine.Nautaa) hp += 3;
            if (PaaraakaAine == PaaraakaAine.Kanaa) hp += 2;
            if (Kastike == Kastike.Curry) hp += 1;

            return hp;
        }
    }
}
