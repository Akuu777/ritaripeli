using System;
using System.Collections.Generic;

namespace ritaripeli
{
    internal class Reppu
    {
        private List<Tavara> tavarat = new List<Tavara>();

        public IReadOnlyList<Tavara> Tavarat => tavarat;

        public void LisaaTavara(Tavara t)
        {
            tavarat.Add(t);
        }

        public void PoistaTavara(Tavara t)
        {
            tavarat.Remove(t);
        }

        public void Listaa()
        {
            if (tavarat.Count == 0)
            {
                Console.WriteLine("Reppu on tyhjä.");
                return;
            }

            for (int i = 0; i < tavarat.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tavarat[i].Nimi}");
            }
        }
    }
}
