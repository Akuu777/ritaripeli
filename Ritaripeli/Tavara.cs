namespace ritaripeli
{
    /// <summary>
    /// Tästä luokasta peritään kaikki erilaiset 
    /// tavarat joita voi säilyttää repussa
    /// </summary>
    internal abstract class Tavara
    {
        public string Nimi { get; set; }

        public Tavara(string nimi)
        {
            Nimi = nimi;
        }
    }
}
