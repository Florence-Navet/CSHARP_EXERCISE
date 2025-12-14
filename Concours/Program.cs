using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static Concours.Notation;

namespace Concours
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello, Examen concours !");
         ChargerDonnées();
         AfficherRésultatsConcours();
         Console.ReadKey();
      }


   }

}
      

     

