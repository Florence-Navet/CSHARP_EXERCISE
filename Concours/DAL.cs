using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Concours;

[Flags] internal enum Etranger { Oui = 0, Non = 1 }
[Flags] internal enum Boursier { Oui = 0, Non = 1 }

//[Flags] internal enum Status { Aucun = 0, Etranger = 1, Boursier =2, Admis = 4}
internal class DAL
   {

   static string[] LibellésEtranger = { "O", "N" };
   static string[] LibellésBoursier = { "O", "N" };


   public static List<(string nom, string prenom, 
      Etranger etranger,
      Boursier boursier,
      float note)> ChargerDonnées()
   {
      string[] lignes = File.ReadAllLines("Etudiants.csv");

      var etudiants = new List<(string nom, string prenom, 
         Etranger etranger,
         Boursier boursier,
         float note)>();
      
      

      for (int i = 1; i < lignes.Length; i++)
      {
         string[] infos = lignes[i].Split(';');

         Etranger estEtranger = infos[2] == "O"
                ? Etranger.Oui
                : Etranger.Non;

         Boursier estBoursier = infos[3] == "O"
             ? Boursier.Oui
             : Boursier.Non;


         float note = float.Parse(
                infos[4],
                CultureInfo.GetCultureInfo("fr-FR")
            );

         etudiants.Add((
                 infos[0],
                 infos[1],
                 estEtranger,
                 estBoursier,
                 note
             ));

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



   public static List<(string nom, string prenom)>
RemplacerEtudiantsAdmis(string nomRefus, string prenomRefus)
   {
      var etudiants = ChargerDonnées();

      if (etudiants == null) return new();

      int NB_ADMIS = 50;

      var classement = etudiants
         .OrderByDescending(e => e.note)
         .ToList();


      var admis = classement.Take(NB_ADMIS).ToList();


      for (int i = 0; i < admis.Count; i++)
      {
         if (admis[i].nom == nomRefus &&
            admis[i].prenom == prenomRefus)
         {
            admis[i] = classement[NB_ADMIS];
            break;
         }
      }




      return admis
         .Select(e => (e.nom,e.prenom))
         .ToList();
   }

}

