using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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

        //static bool PoserQuestions(int indicePays)
        //{
        //   //if (indicePays < 0 ||  indicePays > pays.Length)
        //   //{
        //   //   return false;
        //   //}

        //   Console.WriteLine($"Quelle est la capitale de {pays[indicePays]} ?");
        //   string? rep = Console.ReadLine();

        //   if (rep?.ToUpper() == capitales[indicePays].ToUpper())
        //   {
        //      Console.WriteLine($"Bravo t'es trop smart, tu as trouvé !!");
        //      return true;
        //   }
        //   else
        //   {
        //      Console.WriteLine($"T'es trop nul la réponse était : {capitales[indicePays]}");
        //      return false;
        //   }



        //}
        static bool PoserQuestions(int numQuestions)
        {

            Console.WriteLine($"Quelle est la capitale de {pays[numQuestions]} ?");
            string? rep = Console.ReadLine();

            if (rep?.ToUpper() == capitales[numQuestions].ToUpper())
            {
                Console.WriteLine($"Bravo t'es trop smart, tu as trouvé !!");
                return true;
            }
            else
            {
                Console.WriteLine($"T'es trop nul la réponse était : {capitales[numQuestions]}");
                return false;
            }


        }

        public static (int, int, int) Generer3Numeros()
        {
            (int n1, int n2, int n3) numeros;
            Random rand = new Random();
            numeros.n1 = rand.Next(1, 11);
            numeros.n2 = rand.Next(1, 11);
            numeros.n3 = rand.Next(1, 11);

            return numeros;

        }

        public static (int, int, int) Saisir3Numeros()
        {
            (int n1, int n2, int n3) numeros;
            numeros.n1 = SaisirNombre(1, 10);
            numeros.n2 = SaisirNombre(1, 10);
            numeros.n3 = SaisirNombre(1, 10);
            return numeros;

        }

        static int SaisirNombre(int min, int max)
        {
            bool repOk;
            int nombre;
            do
            {
                Console.WriteLine($"Entrez un nombre entre {min} et {max} :");
                string? saisie = Console.ReadLine();
                repOk = int.TryParse(saisie, out nombre) && nombre >= min && nombre <= max;


            } while (!repOk);

            return nombre;
        }

        static bool DemandeSiRejouer()
        {


            Console.WriteLine("Voulez-vous rejouer O/N ?");
            string? reponse = Console.ReadLine();
            if (reponse == "O" || reponse == "o")
            {
                Console.WriteLine("\nC'est partie pour une nouvelle game !!");
                Console.Clear();
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

                int BonnesReponses = 0;
                for (int i = 0; i < pays.Length; i++)
                //for (int i = pays.Length - 1; i >= 0; i--)
                {
                    //if (i % 2 == 0)
                    //{
                    if (PoserQuestions(i)) BonnesReponses++;

                    //bool reponseCorrecte = PoserQuestions(i);


                    //Console.WriteLine(pays[i]);
                    //string? rep = Console.ReadLine();
                    //if (rep?.ToUpper() == capitales[i].ToUpper())
                    //{
                    //   Console.WriteLine("Bravo tu as trouvé, tu es vraiment trop fort");
                    //BonnesReponses++;
                    //}
                    //else
                    //{
                    //   Console.WriteLine($"Non la réponse était {capitales[i]}");

                    //}

                    //Console.WriteLine($"Tu as eu {BonnesReponses} bonnes réponses sur {pays.Length}");




                    //}

                }
                Console.WriteLine($"Tu as eu {BonnesReponses} bonnes réponses sur {pays.Length}");

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

                foreach (int numero in numerosQuestions)


                {
                    if (numero > 0 && numero <= pays.Length && PoserQuestions(numero - 1)) nbBonnesReponses++;
                }

                Console.WriteLine($"Tu as eu {nbBonnesReponses} bonnes réponses sur {pays.Length}");
                rejouer = DemandeSiRejouer();
                Console.Clear();
            }



        }

    }
}




