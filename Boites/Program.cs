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
         



         Boite b1 = new Boite(20, 20, 10);
         Console.WriteLine($"Boite de volume {b1.Volume} en {b1.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");

         Boite b2 = new Boite(20, 30, 10, Matieres.Bois);
         Console.WriteLine($"Boite de volume {b2.Volume} en {b2.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");

         Boite b3 = new Boite(20, 30, 10, Matieres.Bois);
         Console.WriteLine($"Boite de volume {b3.Volume} en {b3.Matiere} ");
         Console.WriteLine($"Nombre de boites {Boite.NbBoites}");

         #region Liste ajout d'élements
         Console.WriteLine();
         bool res = b3.TryAddArticle(new Article("lot de 6 assiettes plates", 4000));
         Console.WriteLine(b3.Description);
         res = b3.TryAddArticle(new Article("lot de 12 couverts", 1000));
         Console.WriteLine(b3.Description);
         res = b3.TryAddArticle(new Article("lot de 6 verres", 2000));
         Console.WriteLine(b3.Description);



;

         Console.WriteLine("transfert :");

         // Transfert du contenu de la boîte b3 vers la boîte vide b2 de même volume
         int nbArticlesTransf = b3.TransfererContenuVers(b2);
         Console.WriteLine($"{nbArticlesTransf} articles transférés");
         Console.WriteLine(b3.Description);
         Console.WriteLine(b2.Description);

         // Transfert du contenu de la boîte b2 vers la boîte vide b1 trop petite
         nbArticlesTransf = b2.TransfererContenuVers(b1);
         Console.WriteLine($"{nbArticlesTransf} articles transférés");
         Console.WriteLine(b2.Description);
         Console.WriteLine(b1.Description);


         #endregion



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