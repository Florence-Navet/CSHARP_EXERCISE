using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Concours.DAL;
using static Concours.Program;

namespace Concours;

internal enum Mentions { E = 0, P = 10, AB = 12, B = 14, TB = 16 }

internal class Notation
{
   static string[] LibellésMentions = { "Echec", "Passable", "Assez bien", "Bien", "Très bien" };



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

      
      var etudiants = DAL.ChargerDonnées();

      int NbAdmis = 50;

      if (etudiants == null) return;

      //var etudiantsTries = etudiants.OrderByDescending(e => e.note).ToList();
      var etudiantsTries = etudiants
        .OrderBy(e => e.etranger)
        .ThenBy(e => e.boursier)
        .ThenByDescending(e => e.note)
        .ToList();

      Console.WriteLine($"Résultat du concours :\n");

      Console.WriteLine(
    $"{"Nom",-12} {"Prénom",-12} {"Note",5} {"Mention",-12} {"Etr.",-4} {"Bours.",-6} Statut"
);
Console.WriteLine(new string('-', 65));

      for (int i = 0; i < etudiantsTries.Count; i++)
      {
         var e = etudiantsTries[i];
         var (mentionEnum, libelle) = GetMention(e.note);
         //string mention = GetMention(e.note);

         string admis = (i < NbAdmis) ? "Admis" : "";

         Console.WriteLine(
          $"{e.nom,-12} {e.prenom,-12} : " +
          $"{e.note,5:F1} " +
          $"{libelle,-12} " +
          $"{e.etranger,-4} {e.boursier,-4} " +
          $"{admis}"
      );

         //Console.WriteLine($"{e.nom,-12} {e.prenom,-12} : {e.note,5:F1}  {libelle,-12} {admis}");

         //Console.WriteLine($"{e.nom,-12} {e.prenom,-12} : {e.note,5:F1}  {mention,-12} {admis}");

      }
      AfficherTexte($"{NbAdmis} étudiants ont été admis sur {etudiants.Count}", ConsoleColor.DarkYellow);
   }


   public static void MethodeAppel()
   {
      var refus = new (string nom, string prenom)[] { ("Douglas", "Léa"), ("Cartier", "Claude"), ("Leduc", "Justin") };

      foreach (var r in refus)
      {
         var anciensAdmis = RemplacerEtudiantsAdmis(r.nom, r.prenom);

         var remplaçant = anciensAdmis.Last();
         AfficherTexte(
             $"Remplacement de {r.nom} {r.prenom} par {remplaçant.nom} {remplaçant.prenom}", ConsoleColor.DarkRed);




      }



      Console.WriteLine();
      AfficherTexte("Nouvelle liste des admis après remplacements :\n", ConsoleColor.Black);
      AfficherRésultatsConcours();

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



/*
 * using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concours;

internal enum Mentions { E=0, P=10, AB=12, B=14, TB=16 }

internal class Notation
{
	static string[] LibellésMentions = { "Echec", "Passable", "Assez bien", "Bien", "Très bien" };
	

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
}
 */