using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
   public enum Matieres { Carton, Plastique, Bois, Metal }
   internal class Boite
   {

      #region Propriétes en lecture seule
      public double Hauteur { get; } = 30;
      public double Largeur { get; } = 30;
      public double Longueur { get; } = 30;
      public Matieres Matiere { get; } = Matieres.Carton;
      public double Volume => Hauteur * Largeur * Longueur;

      public static int NbBoites { get; private set; }

     

      public string Destinataire { get; private set; } = string.Empty;

      public bool Fragile { get; private set; }


      #endregion

      #region Constructeurs
      public Boite(double hauteur, double largeur, double longueur)
      {
         Hauteur = hauteur;
         Largeur = largeur;
         Longueur = longueur;
         NbBoites++;
      }

      public Boite(double hauteur, double largeur, double longueur, Matieres matiere) : this(hauteur, largeur, longueur)
      {
         Matiere = matiere;
      }
      #endregion

      #region Methodes publiques

      /// <summary>
      /// permet d'affecter la valeur de la prop du destinataire
      /// </summary>
      public void Etiqueter(string dest)
      {
         Destinataire = dest;
       

      }

      public void Etiqueter(string dest, bool f)
      {
         Etiqueter(dest);
         Fragile = f;
         
      }

      public static bool Comparer(Boite a, Boite b)
      {
         return (a.Hauteur == b.Hauteur && a.Longueur == b.Longueur && a.Largeur == b.Largeur && a.Matiere == b.Matiere);
           
       
      }

      public bool Comparer (Boite a)
      {
         //return (a.Hauteur == Hauteur && a.Longueur == Longueur && a.Largeur == Largeur && a.Matiere == Matiere);
         return (Comparer(a, this)); // instance courrante de la classe
      }
      #endregion
   }
}
