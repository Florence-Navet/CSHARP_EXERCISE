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



         //Boite b1= new Boite();
         



         Boite b1 = new Boite(20, 10, 10);
         Console.WriteLine($"Boite de volume {b1.Volume} en {b1.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");

         Boite b2 = new Boite(30, 10, 15, Matieres.Bois);
         Console.WriteLine($"Boite de volume {b2.Volume} en {b2.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");

         Boite b3 = new Boite(30, 10, 15, Matieres.Bois);
         Console.WriteLine($"Boite de volume {b3.Volume} en {b3.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");



         b1.Etiqueter("M.Blabla", false);
         Console.WriteLine($"Boite de {b1.Destinataire} {(b1.Fragile ? "Fragile" : "Non Fragile" )} ");

         b2.Etiqueter("Mme Lola", true);
         Console.WriteLine($"Boite de {b2.Destinataire} {(b2.Fragile ? "Fragile" : "Non Fragile")} ");


         Console.WriteLine($"Boites identiques b1 et b2: {Boite.Comparer(b1, b2)}");
         Console.WriteLine();


         Console.WriteLine($"Boites identiques b2 et b3 : {Boite.Comparer(b2, b3)}");

         //comparer instance courante
         Console.WriteLine($"Boites identiques b1 et b2 - methode d'instance : {b1.Comparer(b2)}");
         Console.WriteLine($"Boites identiques b2 et b3 - methode d'instance : {b2.Comparer(b3)}");


         Etiquette etiquette1 = new Etiquette { 
            Texte = "M.Doe", 
            couleur = Couleurs.Rouge, 
            format = Formats.M 
         };

         Console.WriteLine($"Etiquette marquee {etiquette1.Texte}, de couleur {etiquette1.couleur} et de format {etiquette1.format}");

     


      }

   }
    
}