namespace ritaripeli
{
    public class Lompakko
    {
        public int Rahat { get; private set; }

        public Lompakko(int aloitusRahat)
        {
            Rahat = aloitusRahat;
        }

        public void LisaaRahaa(int maara)
        {
            Rahat += maara;
        }

        public void VahennaRahaa(int maara)
        {
            Rahat -= maara;
        }
    }
}
