using System.Numerics;

namespace CalendrierPerpetuel;

internal class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Hello, Calendrier Perpertuel !");


      //CalculateurCalendrier.AfficherDatesDebutsSaisons(2025);

      Console.WriteLine("***************************************************************");

      //CalculateurCalendrier.CalculerJoursFériésFrançais(2025);


      //CalculateurCalendrier.AfficherHeureEteHeureHiver(2025);


      Console.WriteLine("***************************************************************");




      int annee = CalculateurCalendrier.SaisirAnnee(1900, 2035);


      CalculateurCalendrier.AfficherDatesDebutsSaisons(annee);

      Console.WriteLine("***************************************************************");

      CalculateurCalendrier.CalculerJoursFériésFrançais(annee);


      CalculateurCalendrier.AfficherHeureEteHeureHiver(annee);


      Console.WriteLine("***************************************************************");

      CalculateurCalendrier.AfficherAnniversaire(annee);




   }

 
}
