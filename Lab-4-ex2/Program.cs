using System;
using System.IO;

namespace ProiectTema
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cuvinte = CitesteCuvinte("C:\\Users\\filip\\OneDrive\\Desktop\\Liviu\\USV\\Anul 2\\SEM.2\\PIU\\Lab\\Lab-4-ex2\\Lab-4-ex2\\cuvinte.txt");

            string[][] tablouCuvinte = new string[26][];

            for (int i = 0; i < 26; i++)
            {
                tablouCuvinte[i] = new string[0];
            }

            foreach (string cuvant in cuvinte)
            {
                if (!string.IsNullOrEmpty(cuvant))
                {
                    char primaLitera = char.ToUpper(cuvant[0]);
                    int index = primaLitera - 'A';

                    string[] temp = new string[tablouCuvinte[index].Length + 1];
                    Array.Copy(tablouCuvinte[index], temp, tablouCuvinte[index].Length);
                    temp[temp.Length - 1] = cuvant;
                    tablouCuvinte[index] = temp;
                }
            }

            for (int i = 0; i < tablouCuvinte.Length; i++)
            {
                char litera = (char)('A' + i);
                Console.WriteLine($"Cuvinte care încep cu litera {litera}:");

                foreach (string cuvant in tablouCuvinte[i])
                {
                    Console.WriteLine(cuvant);
                }

                Console.WriteLine();
            }
            Console.WriteLine("Apasă Enter pentru a închide...");
            Console.ReadLine();
        }

        static string[] CitesteCuvinte(string numeFisier)
        {
            string[] cuvinte;

            try
            {
                cuvinte = File.ReadAllLines(numeFisier);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A apărut o eroare la citirea fișierului: {ex.Message}");
                cuvinte = new string[0];
            }

            return cuvinte;
        }
    }
}
