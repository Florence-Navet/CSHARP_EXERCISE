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



         //b1.Etiqueter("M.Blabla", false);
         //Console.WriteLine($"Boite de {b1.Destinataire} {(b1.Fragile ? "Fragile" : "Non Fragile" )} ");

         //b2.Etiqueter("Mme Lola", true);
         //Console.WriteLine($"Boite de {b2.Destinataire} {(b2.Fragile ? "Fragile" : "Non Fragile")} ");

         // etiquetage relation de composition
         //b1.Etiqueter("M. John Doe, 3 rue blabla 0124 DISNEYLAND", 1234567, false);

         //if (b1.EtiquetteColis != null)
         //{
         //   Console.WriteLine($"""
         //      Colis N° {b1.EtiquetteColis.NumeroColis}
         //      Destinataire : {b1.EtiquetteColis.Destinataire}
         //      {(b1.Fragile ? "Fragile" : "Non Fragile")}
         //      """);
         //}

         //relation d'agregation
         Client cli = new Client
         {
            Numero = 15,
            Nom = "Doe",
            Prenom = "John",
            Adresse = "15, rue du blabla 0123 DISNEYWORLD"
         };

         b2.Etiqueter(cli, 123456, true);

         if (b2.EtiquetteColis != null)
         {
            Client cl = b2.EtiquetteColis.Destinataire;

            Console.WriteLine($"""
               Colis N° {b2.EtiquetteColis.NumeroColis}
               Destinataire : {cli.Nom} {cli.Prenom} {cli.Adresse}
               {(b2.Fragile ? "Fragile" : "Non Fragile")}
               """);
         }


         Console.WriteLine($"Boites identiques b1 et b2: {Boite.Comparer(b1, b2)}");
         Console.WriteLine();


         Console.WriteLine($"Boites identiques b2 et b3 : {Boite.Comparer(b2, b3)}");

         //comparer instance courante
         Console.WriteLine($"Boites identiques b1 et b2 - methode d'instance : {b1.Comparer(b2)}");
         Console.WriteLine($"Boites identiques b2 et b3 - methode d'instance : {b2.Comparer(b3)}");


         //Etiquette etiquette1 = new Etiquette { 
         //   Destinataire = "M.Doe", 
         //   Couleur = Couleurs.Rouge, 
         //   Format = Formats.M 
         //};

         //Console.WriteLine($"Etiquette marquee {etiquette1.Destinataire}, de couleur {etiquette1.couleur} et de format {etiquette1.format}");

     


      }

   }
    
}