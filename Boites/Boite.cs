using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

      public string Description // affiche le libelle de la description
      { 
         get
         {
            string desc = $"Boite de volume {Volume} en {Matiere} contenant : \n";
            foreach (Article article in Articles)
            {
               desc += $" - {article.Libelle}\n";
            }
            return desc ;
         }
             
      }

     

      public Etiquette? EtiquetteColis { get; private set; }
      private List<Article> _articles;

      public ReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

      public bool Fragile { get; private set; }


      #endregion
      

      #region Constructeurs
      public Boite(double hauteur, double largeur, double longueur)
      {
         Hauteur = hauteur;
         Largeur = largeur;
         Longueur = longueur;
         _articles = new List<Article>();
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
      public void Etiqueter(Client dest, long numeroColis) // relation d'agregation
      {
         EtiquetteColis = new Etiquette
         {

            Destinataire = dest,
            NumeroColis = numeroColis,
            Couleur = Couleurs.Blanc,
            Format = Formats.XL


         };
      }

      public void Etiqueter(Client dest, long numeroColis, bool f)
      {
         Etiqueter(dest, numeroColis);
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

      /// <summary>
      /// Tente d'ajouter un article dans la boite si la place le permet
      /// </summary>
      /// <param name="article">article à ajouter</param>
      /// <returns>True si l'article a été" ajouter, false sinon</returns>
      public bool TryAddArticle(Article article)
      {

         double VolumeOccupe = 0;

         foreach (Article a in _articles)
         {
            VolumeOccupe += a.Volume;
         }

         if (VolumeOccupe + article.Volume <= Volume)
         {
            _articles.Add(article);
            return true;
         }
         return false;

      }

      /// <summary>
      /// transfere les articles de la boite courante vers la boite passée en parametre
      /// seuls les articles qui tiennent dans la boite de destination sont transferes
      /// </summary>
      /// <param name="b">Boite de destination</param>
      /// <returns>Nb d'article transferes</returns>
      public int TransfererContenuVers(Boite b)
      {
         int nbArticlesTransf = 0;

         for (int i = _articles.Count - 1; i >= 0; i--)
         {
            if (b.TryAddArticle(_articles[i]))
            {
               _articles.RemoveAt(i);
               nbArticlesTransf++;
            }
         }

         return nbArticlesTransf;
      }
      #endregion
   }
}
