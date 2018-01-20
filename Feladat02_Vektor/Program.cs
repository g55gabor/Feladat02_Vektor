using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat02_Vektor
{
    class Program
    {

        public static void sorozatGeneralas(ref bool[] tomb)
        {
            ErmeFeldobo ermeDobas = new ErmeFeldobo();

            for (int i = 0; i < tomb.Length; i++)
            {
                bool dobas = ermeDobas.FeldobasEredmenye();
                tomb[i] = dobas;
            }            
        }

        public static double hamisakSzazaleka(ref bool[] tomb)
        {
            int szam = 0;
            double szazalek = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (!tomb[i]) { szam++; }
            }
            szazalek =(double)szam * 100 / tomb.Length;
            return szazalek;
        }

        public static double igazakSzazaleka(ref bool[] tomb)
        {
            int szam = 0;
            double szazalek = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i]) { szam++; }
            }
            szazalek = (double)szam  / tomb.Length*100;
            return szazalek;
        }



        public static void sorozatKiiras(ref bool[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i]) {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("T");
                }
                else {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("F");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("-");

            }
        }

        static void Main(string[] args)
        {

            bool[] sorozat = new bool[60];

            sorozatGeneralas(ref sorozat);
            sorozatKiiras(ref sorozat);
            Console.WriteLine();
            Console.WriteLine(string.Format("Az írások száma  : {0:F2}%", hamisakSzazaleka(ref sorozat)));
            Console.WriteLine(string.Format("Az fejek száma   : {0:F2}%", igazakSzazaleka(ref sorozat)));



            Console.ReadLine();
        }
    }

    class ErmeFeldobo
    {
        Random generator = new Random();

        /// <summary>
        /// Feldobunk egy érmet, és az eredméynt visszadjuk
        /// </summary>
        /// <returns>0=Fej, 1=Írás</returns>
        internal bool FeldobasEredmenye()
        {
            var dobas = generator.Next(2);
            if (dobas==0) { return false; }
            else { return true; }
        }
    }
}
