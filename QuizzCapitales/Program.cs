using System.Numerics;

namespace QuizzCapitales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //Quizz.Jouer();

            //Quizz.Jouer(2, 4, 5);

            //int a, b, c;

            //Quizz.Generer3Numeros(out a, out b, out c);
            //Console.WriteLine($"Les trois numéros générés sont {a}, {b}, et {c}");
            Console.WriteLine("Test pour test contrl H");
            Console.WriteLine("Test pour test contrl H");
            Console.WriteLine("Test pour test contrl H");
            //Quizz.Jouer(a,b,c);

            //(int n1, int n2, int n3) = Quizz.Generer3Numeros();

            (int n1, int n2, int n3) = Quizz.Saisir3Numeros();



            Console.WriteLine($"Les trois numéros tirés sont {n1}, {n2} et {n3}.");

            Quizz.Jouer(n1, n2, n3);






        }
    }
}
