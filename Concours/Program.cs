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
      AfficherEtudiantsEtrangerAdmis();
      Console.ReadKey();
      AfficherEtudiantsFrançaisBoursiers();
      Console.ReadKey();
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


   

  

