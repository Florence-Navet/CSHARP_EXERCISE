using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using static Concours.DAL;
using static Concours.Notation;


namespace Concours;

internal class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Hello, Examen concours !");
      ChargerDonnées();
      AfficherRésultatsConcours();
      Console.ReadKey();
      Console.Clear();
      AfficherEtudiantsEtrangerAdmis();
      Console.ReadKey();
      Console.Clear();
      AfficherEtudiantsFrançaisBoursiers();
      Console.ReadKey();
      Console.Clear();
      MethodeAppel();
     
   }

   public static void AfficherEtudiantsEtrangerAdmis()
   {
      var etudiants = DAL.ChargerDonnées();

      int nbAdmis = 50;


      var top50 = etudiants
    .OrderByDescending(e => e.note)
    .Take(nbAdmis)
    .ToList();

      var boursiersEtrangers = top50
    .Where(e => e.boursier == Boursier.Oui &&
                e.etranger == Etranger.Oui)
    .ToList();



      //if (etudiants == null) return;

  

      //var top50 = etudiants
      //   .OrderBy(e => e.etranger)
      //   .ThenBy(e => e.boursier)
      //   .ThenByDescending(e => e.note)
      //   .Take(nbAdmis)
      //   .ToList();



      if (etudiants != null)
      {
         Console.WriteLine();
         Console.WriteLine(new string('-', 55));
         Console.WriteLine("Etudiants étrangers admis :\n");

         int nbEtrangersAdmis = 0;

         Console.WriteLine(
           $"{"Nom",-12} {"Prénom",-12}  {"Note",5}   {"Mention",-12} {"Bours.",-6}"
           );
         Console.WriteLine(new string('-',55));

         foreach (var e in boursiersEtrangers)
         {
            //if (e.etranger == Etranger.Oui && e.note >= 10)
            //{
               var (_, libelle) = GetMention(e.note);
               nbEtrangersAdmis++;

            Console.WriteLine(
         $"{e.nom,-12} {e.prenom,-12} " +
         $"{e.note,5:F1} " +
         $"{libelle,-12} " +
         $"{e.boursier,-6}"
         );
            //};
         }
         AfficherTexte($"{boursiersEtrangers.Count} étudiants etrangers ont été admis sur {top50.Count}", ConsoleColor.Green);
      }
   }
   public static void AfficherEtudiantsFrançaisBoursiers()
   {
      var etudiants = DAL.ChargerDonnées();
      if (etudiants == null) return;

      int nbAdmis = 50;



      var top50 = etudiants
    .OrderByDescending(e => e.note)
    .Take(nbAdmis)
    .ToList();

      var boursiersFrançais = top50
    .Where(e => e.boursier == Boursier.Oui &&
                e.etranger == Etranger.Non)
    .ToList();

    

  

      if (etudiants != null)
      {
         Console.WriteLine();
         Console.WriteLine(new string('-', 55));
         Console.WriteLine("Etudiants français admis :\n");
         int NbFrançaisAdmis = 0;

         Console.WriteLine(
           $"{"Nom",-12} {"Prénom",-12}  {"Note",5}   {"Mention",-12}"
           );
         Console.WriteLine(new string('-', 55));

         foreach (var e in boursiersFrançais)
         {
            //if (e.etranger == Etranger.Non && 
            //   e.boursier == Boursier.Oui &&
            //   e.note >= 10)
            //{
               var (_, libelle) = GetMention(e.note);
               NbFrançaisAdmis++;

               Console.WriteLine(
                  $"{e.nom,-12} {e.prenom,-12} " +
                  $"{e.note,5:F1}   " +
                  $"{libelle,-12}");
            //}
            //;
         }
        AfficherTexte($"{boursiersFrançais.Count} étudiants français ont été admis sur {top50.Count}", ConsoleColor.Cyan);
      }
   }

   public static void AfficherTexte(string texte, ConsoleColor couleur)
   {
      
      Console.ForegroundColor = couleur;
      Console.WriteLine(texte);
      Console.ResetColor();

      

   }




}






/*
 * namespace Concours;

internal class Program
{
	static void Main(string[] args)
	{
		DAL.ChargerDonnées();
		AfficherRésultatsConcours();
		Console.ReadKey();
		Console.Clear();

		AfficherEtudiantsEtrangersAdmis();

		Console.ReadKey();
		Console.Clear();

		AfficherEtudiantsFrançaisBoursiers();

		Console.ReadKey();
		Console.Clear();

		string[] remplacés = { "Douglas Léa", "Cartier Claude", "Leduc Justin" };
		string[] remplaçants = DAL.RemplacerEtudiantsAdmis(remplacés);
		for (int r = 0; r < remplacés.Length; r++)
		{
			Console.WriteLine($"Remplacement de {remplacés[r]} par {remplaçants[r]}");
		}
		Console.WriteLine();
		AfficherRésultatsConcours();
		Console.ReadKey();
	}

	/// <summary>
	/// Affiche le texte passé en paramètre avec la couleur spécifiée
	/// </summary>
	/// <param name="texte">texte à afficher</param>
	/// <param name="couleur">couleur de police à utiliser</param>
	static void AfficherTexte(string texte, ConsoleColor couleur = ConsoleColor.Blue)
	{
		ConsoleColor couleurOrigine = Console.ForegroundColor;
		Console.ForegroundColor = couleur;
		Console.WriteLine(texte);
		Console.ForegroundColor = couleurOrigine;
	}

	// Affiche les résultats du concours (étudiants avec leurs moyennes et mentions)
	static void AfficherRésultatsConcours()
	{
		if (DAL.Etudiants == null) return;

		AfficherTexte($"Résultats du concours :\n");
		for (int i = 0; i < DAL.Etudiants.Length; i++)
		{
			(Mentions mention, string libellé) mention = Notation.GetMention(DAL.Etudiants[i].moyenne);
			string res = DAL.Etudiants[i].statut.HasFlag(Statuts.Admis) ? "Admis" : string.Empty;

			Console.WriteLine($"{DAL.Etudiants[i].nom,-20} : {DAL.Etudiants[i].moyenne,5:N1}  {mention.libellé,-12} {res}");
		}

		AfficherTexte($"\n{DAL.NbAdmis} étudiants admis sur {DAL.Etudiants.Length}", ConsoleColor.DarkGreen);
	}

	// Affiche les noms des étudiants étranger admis à l'école
	static void AfficherEtudiantsEtrangersAdmis()
	{
		if (DAL.Etudiants == null) return;

		AfficherTexte("Etudiants étrangers admis :\n");
		int cpt = 0;

		for (int i = 0; i < DAL.Etudiants.Length; i++)
		{
			if (DAL.Etudiants[i].statut.HasFlag(Statuts.Etranger | Statuts.Admis))
			{
				cpt++;
				Console.WriteLine($"{DAL.Etudiants[i].nom,-20}");
			}
		}

		AfficherTexte($"\nTotal : {cpt} étudiants étrangers admis", ConsoleColor.DarkGreen);
	}

	// Affiche la liste des étudiants français boursiers
	static void AfficherEtudiantsFrançaisBoursiers()
	{
		if (DAL.Etudiants == null) return;

		AfficherTexte("Etudiants français boursiers :\n");
		int cpt = 0;

		for (int i = 0; i < DAL.Etudiants.Length; i++)
		{
			if (!DAL.Etudiants[i].statut.HasFlag(Statuts.Etranger) &
				DAL.Etudiants[i].statut.HasFlag(Statuts.Boursier))
			{
				cpt++;
				Console.WriteLine($"{DAL.Etudiants[i].nom,-20}");
			}
		}

		AfficherTexte($"\nTotal : {cpt} étudiants français boursiers", ConsoleColor.DarkGreen);
	}
}
 */
