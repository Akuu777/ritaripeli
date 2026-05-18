using System;

namespace Ritaripeli
{
    class Program
    {
        static void Main(string[] args)
        {
            Ritari ritari = new Ritari(10, 10); // 10 HP, 10 kultaa

            bool peliKaynnissa = true;

            while (peliKaynnissa)
            {
                Console.Clear();
                Console.WriteLine("Tervetuloa suureen seikkailuun!\n");
                Console.WriteLine($"Tilanne: Sinulla on {ritari.Osumapisteet} osumapistettä ja {ritari.Kulta} kultarahaa.");
                Console.WriteLine("Valitse toiminto:");
                Console.WriteLine("1 Mene nuolikauppaan");
                Console.WriteLine("2 Mene ravintolaan");
                Console.WriteLine("3 Lähde taisteluun");
                Console.WriteLine("4 Käytä repussa olevia esineitä");
                Console.WriteLine("5 Lopeta peli");

                Console.Write("> ");
                string valinta = Console.ReadLine();

                switch (valinta)
                {
                    case "1":
                        Console.WriteLine("Nuolikauppa ei ole vielä valmis.");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Ravintola ei ole vielä valmis.");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Taistelu ei ole vielä valmis.");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Repun käyttö ei ole vielä valmis.");
                        Console.ReadKey();
                        break;

                    case "5":
                        peliKaynnissa = false;
                        break;

                    default:
                        Console.WriteLine("Virheellinen valinta.");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("Peli päättyi.");
        }
    }
}