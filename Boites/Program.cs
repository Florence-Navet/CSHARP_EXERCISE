namespace Boites
{
   using System;
   using System.Globalization;
   using System.IO;

   internal static class Program
   {
      static void Main(string[] args)
      {
         
         Console.WriteLine("Hello Boites");

         

         Boite b1= new Boite();

         Console.WriteLine($"Boite de volume {b1.Volume} en {b1.Matiere} ");


         b1.Etiqueter("M.Blabla", false);
         Console.WriteLine($"Boite de {b1.Destinataire} {(b1.Fragile ? "Fragile" : "Non Fragile" )} ");
        

       
      }

   }
    
}