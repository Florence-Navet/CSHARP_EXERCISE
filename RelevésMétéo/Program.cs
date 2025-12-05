namespace RelevésMétéo
{
    using System;
    using System.Globalization;
    using System.IO;

    internal static class Program
    {
        static void Main(string[] args)
        {
            AfficherListe();
            Console.WriteLine();
        }

        static void AfficherListe()
        {
            string[] lignes = File.ReadAllLines("MeteoParis.csv");

            float sommeTemp = 0f;

            for (int i = 1; i < lignes.Length; i++)
            {
                // simplifie le format des heures d'ensoleillement
                string ligne = lignes[i].Replace("h ", "h").Replace("min", "");

                //recupère les infos de la ligne dans un tableau
                string[] infos = ligne.Split(';');

                //construit une ligne sous forme souhaitée
                Console.WriteLine($"{infos[0]}/{infos[1]} : [{infos[2]} ; {infos[3]}] °C\t" +
                    $" {infos[6]} de soleil\t{infos[7]} mm de pluie");

                //ajoute la température au cumul
                if (float.TryParse(infos[4], out float temp))
                    sommeTemp += temp;
            }

            Console.WriteLine();
            Console.WriteLine($"T° moyenne globale : {sommeTemp / (lignes.Length - 1)}");
        }
    }
}