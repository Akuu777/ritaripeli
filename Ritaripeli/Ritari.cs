using ritaripeli;

internal class Ritari
{
    public int Osumapisteet { get; private set; }
    public Lompakko Rahapussi { get; private set; }
    public Reppu Reppu { get; private set; }
    public int Voitot { get; set; }

    public Miekka Ase { get; set; }

    public Ritari(int hp, int raha)
    {
        Osumapisteet = hp;
        Rahapussi = new Lompakko(raha);
        Reppu = new Reppu();
        Ase = new Miekka("Perusmiekka", 3);
    }

    public void OtaVahinkoa(int maara)
    {
        Osumapisteet -= maara;
    }
}