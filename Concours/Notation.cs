using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours;

internal enum Mentions { E = 0, P = 10, AB = 12, B = 14, TB = 16 }

internal class Notation
{
   static string[] LibellésMentions = { "Echec", "Passable", "Assez bien", "Bien", "Très bien" };

   public static List<(string nom, string prenom, bool Etranger, bool Boursier, float note)> ChargerDonnées()
   {
      string[] lignes = File.ReadAllLines("Etudiants.csv");
      var etudiants = new List<(string nom, string prenom, bool Etranger, bool Boursier, float note)>();

      float moyenne = 0f;

      for (int i = 1; i < lignes.Length; i++)
      {
         string[] infos = lignes[i].Split(';');
         bool estEtranger = infos[2] == "O";
         bool estBoursier = infos[3] == "O";
         float note = float.Parse(infos[4], CultureInfo.GetCultureInfo("fr-FR"));

         etudiants.Add((infos[0], infos[1], estEtranger, estBoursier, note));

         //         Console.WriteLine(
         //    $"{infos[0].PadRight(12)} | " +
         //    $"{infos[1].PadRight(10)} | " +
         //    $"{infos[2].PadRight(2)} | " +
         //    $"{infos[3].PadRight(2)} | " +
         //    $"{infos[4].PadRight(5)}"
         //);
         //      }
      }
      return etudiants;
   }

   public static (Mentions, string) GetMention(double note)
   {
      Mentions mention = Mentions.E;
      string libellé = LibellésMentions[0];

      int cpt = 0;
      foreach (Mentions m in Enum.GetValues(typeof(Mentions)))
      {
         if ((int)m <= note)
         {
            mention = m;
            libellé = LibellésMentions[cpt++];
         }
         else
            break;
      }

      return (mention, libellé);
   }

   public static void AfficherRésultatsConcours()
   {
      var etudiants = ChargerDonnées();

      var etudiantsTries = etudiants.OrderByDescending(e => e.note).ToList();

      for (int i = 0; i < etudiantsTries.Count; i++)
      {
         var e = etudiantsTries[i];
         var (mentionEnum, libelle) = GetMention(e.note);
         //string mention = GetMention(e.note);

         string admis = (i < 50) ? "Admis" : "";

         Console.WriteLine($"{e.nom,-12} {e.prenom,-12} : {e.note,5:F1}  {libelle,-12} {admis}");

         //Console.WriteLine($"{e.nom,-12} {e.prenom,-12} : {e.note,5:F1}  {mention,-12} {admis}");

      }
      Console.WriteLine($"50 étudiants ont été admis sur {etudiants.Count}");
   }
}


//public static string GetMention(float moyenne)
//{
//   string mention;

//   switch (moyenne)
//   {
//      case >= 16:
//         mention = "Très bien";
//         break;
//      case >= 14:
//         mention = "Bien";
//         break;
//      case >= 12:
//         mention = "Assez bien";
//         break;
//      case >= 10:
//         mention = "Passable";
//         break;
//      default:
//         mention = "Insuffisant";
//         break;

//   }
//   return mention;

//}
