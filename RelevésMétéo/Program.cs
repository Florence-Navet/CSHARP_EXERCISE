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
            AfficherTableau();
        }

        static void AfficherListe()
        {
            string[] lignes = File.ReadAllLines("MeteoParis.csv");

            float CumulTemp = 0f;

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
                    CumulTemp += temp;
            }

            Console.WriteLine();
            Console.WriteLine($"T° moyenne globale : {CumulTemp / (lignes.Length - 1)}");
        }

        static void AfficherTableau()
        {
            Console.WriteLine("*******************************************************************");
            const string entetes = """
			Mois | T° min | T° max | Soleil | Pluie (mm)
		----------------------------------------------------
		""";

            Console.WriteLine(entetes);


            string[] lignes = File.ReadAllLines("MeteoParis.csv");

            for (int i = 1; i < lignes.Length; i++)
            {
                // simplifie le format des heures d'ensoleillement
                string ligne = lignes[i].Replace("h ", "h").Replace("min", "");

                //recupère les infos de la ligne dans un tableau
                string[] infos = ligne.Split(';');

                //transforme les chaines en nombre
                if (float.TryParse(infos[2], out float tmin) &&
                    float.TryParse(infos[3], out float tmax) &&
                float.TryParse(infos[7], out float pluie))
                {
                    Console.WriteLine($"{infos[0]}/{infos[1]}  |  {tmin,6:N1}  |  {tmax,6:N1}  |  {infos[6],6}  |  {pluie,10:N1}");

                }
                else
                {
                    Console.WriteLine("Erreur à la ligne {0}", i);
                }
            }
            

        }
    }
}