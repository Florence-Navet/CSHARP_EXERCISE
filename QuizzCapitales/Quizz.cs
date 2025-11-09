using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

      // Methode PoserQuestions

      static bool PoserQuestions(int indicePays)
      {
         //if (indicePays < 0 ||  indicePays > pays.Length)
         //{
         //   return false;
         //}

         Console.WriteLine($"Quelle est la capitale de {pays[indicePays]} ?");
         string? rep = Console.ReadLine();

         if (rep?.ToUpper() == capitales[indicePays].ToUpper())
         {
            Console.WriteLine($"Bravo t'es trop smart, tu as trouvé !!");
            return true;
         }
         else
         {
            Console.WriteLine($"T'es trop nul la réponse était : {capitales[indicePays]}");
            return false;
         }



      }

      static bool DemandeSiRejouer()
      {


         Console.WriteLine("Voulez-vous rejouer O/N ?");
         string? reponse = Console.ReadLine();
         if (reponse == "O")
         {
            Console.WriteLine("\nC'est partie pour une nouvelle game !!");
            return true;


         }
         else
         {
            Console.WriteLine("Merci d'avoir jouer avec nous !!");
            return false;

         }
      }

      //Methode statique Jouer

      public static void Jouer()
      {

         bool rejouer = true;


         while (rejouer)
         {

            int nbBonnesReponses = 0;
            for (int i = 0; i < pays.Length; i++)
            //for (int i = pays.Length - 1; i >= 0; i--)
            {
               //if (i % 2 == 0)
               //{

               bool reponseCorrecte = PoserQuestions(i);


               //Console.WriteLine(pays[i]);
               //string? rep = Console.ReadLine();
               //if (rep?.ToUpper() == capitales[i].ToUpper())
               //{
               //   Console.WriteLine("Bravo tu as trouvé, tu es vraiment trop fort");
               nbBonnesReponses++;
               //}
               //else
               //{
               //   Console.WriteLine($"Non la réponse était {capitales[i]}");

               //}

               Console.WriteLine($"Tu as eu {nbBonnesReponses} bonnes réponses sur {pays.Length}");




               //}

            }

            rejouer = DemandeSiRejouer();

         }
         Console.Clear();
      }

      public static void Jouer(params int[] numerosQuestions)
      {
         bool rejouer = true;


         while (rejouer)
         {

            int nbBonnesReponses = 0;
            int NbQuestionsPosees = 0;

            foreach (int numero in numerosQuestions)
            {
               if (numero >= 1 && numero <= 10)
               {

                  int indice = numero - 1;

                  bool reponseCorrecte = PoserQuestions(indice);

                  if (reponseCorrecte)
                  {
                     nbBonnesReponses++;

                  }
                  NbQuestionsPosees++;
               } else
               {
                  Console.WriteLine($"Le numero {numero} est invalide. Ignoré");
               }

            }
            Console.WriteLine($"Tu as eu {nbBonnesReponses} bonnes réponses sur {pays.Length}");

            rejouer = DemandeSiRejouer();
              

            
         }
         Console.Clear( );

   

      }

   }
}
  
      
   

