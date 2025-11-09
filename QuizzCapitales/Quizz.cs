using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzCapitales
{
   internal class Quizz
   {
      //public static 
      static string[] pays = { "France", "Allemagne", "Espagne", "Italie", "Grèce", "Suède", "Portugal", "Belgique", "Suisse", "Norvège" };

      static string[] capitales = { "Paris", "Berlin", "Madrid", "Rome", "Athènes", "Stockholm", "Lisbonne", "Bruxelles", "Berne", "Oslo" };

      //Methode statique Jouer

      public static void Jouer()
      {

         bool rejouerOk = true;


         while (rejouerOk)
         {

            int nbBonnesReponses = 0;
            for (int i = 0; i < pays.Length; i++)
            //for (int i = pays.Length - 1; i >= 0; i--)
            {
               //if (i % 2 == 0)
               //{
               Console.WriteLine("Donne-moi la capitale de ce pays ? : ");
               Console.WriteLine(pays[i]);
               string? rep = Console.ReadLine();


               if (rep?.ToUpper() == capitales[i].ToUpper())
               {
                  Console.WriteLine("Bravo tu as trouvé, tu es vraiment trop fort");
                  nbBonnesReponses++;
               }
               else
               {
                  Console.WriteLine($"Non la réponse était {capitales[i]}");

               }

               Console.WriteLine($"Tu as eu {nbBonnesReponses} bonnes réponses sur {pays.Length}");




               //}

            }
            Console.WriteLine("Voulez-vous rejouer O/N ?");
            string? reponse = Console.ReadLine();
            if (reponse == "O")
            {
               rejouerOk = true;
               Console.WriteLine("\nC'est partie pour une nouvelle game !!");


            }
            else
            {
               Console.WriteLine("Merci d'avoir jouer avec nous !!");
               break;

            }
         }
         Console.Clear();
      }
   }
}
