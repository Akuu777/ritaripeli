internal class Lompakko
{
    private int rahat;

    public Lompakko(int alkuRahat)
    {
        rahat = alkuRahat;
    }

    public int Rahat
    {
        get { return rahat; }
    }

    public int OtaRahaa(int maara)
    {
        if (rahat >= maara)
        {
            rahat -= maara;
            return maara;
        }
        return 0;
    }
}
