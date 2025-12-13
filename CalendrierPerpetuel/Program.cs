using System.Numerics;

namespace CalendrierPerpetuel;

internal class Program
{
   static void Main(string[] args)
   {
      Console.WriteLine("Hello, Calendrier Perpertuel !");


      CalculateurCalendrier.AfficherDatesDebutsSaisons(2025);

      Console.WriteLine("***************************************************************");

      CalculateurCalendrier.CalculerJoursFériésFrançais(2025);










   }
}
