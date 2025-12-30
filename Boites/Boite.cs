using System;
using System.Collections.Generic;
using System.Linq;
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
      public double Volume => Hauteur * Largeur * Longueur;

      public Matieres Matiere { get; } = Matieres.Carton;

      public string Destinataire { get; private set; } = string.Empty;

      public bool Fragile { get; private set; }


      #endregion

      #region Methode publique

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
      #endregion
   }
}
