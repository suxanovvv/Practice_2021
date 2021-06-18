using System;

namespace Aquarium
{
    internal class Program
    {
        public static Aquarium Aquarium;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Позначки:\n" +
                              "S - Stone\n" +
                              "H - Herb\n" +
                              "F - Травоїдна риба хлопчик\n" +
                              "f - Травоїдна рибка дівчинка\n" +
                              "P - Хижа риба хлопчик\n" +
                              "p - Хижа риба дівчинка\n" +
                              "0 - молода\n" +
                              "1 - зріла\n" +
                              "2 - стара\n" +
                              "Nh - не голодна\n" +
                              "Lh - трохи голодна\n" +
                              "Vh - дуже голодна\n");
            Aquarium = new Aquarium();
            Aquarium.Init();
            int i = 0;
            do
            {
                Console.WriteLine("Ітерація " + i + "\n");
                Aquarium.NewIteration();
                Console.WriteLine(Aquarium.ToString());
                i++;
                Console.ReadKey();
            } while (true);
        }
    }
}