using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelesDocs
{
    internal class Document
    {

        #region données et constructeurs statiques
        public static readonly List<Document> Modeles;

        static Document()
        {
            Modeles = new List<Document>();
            Modeles.Add(new Document
            {
                Titre = "Modèle A",
                DateCreation = new DateTime(2023, 1, 1),
                Marges = (2.5, 2.5, 2.5, 2.5)
            });

            Modeles.Add(new Document
            {
                Titre = "Modèle B",
                DateCreation = new DateTime(2023, 6, 30),
                Marges = (2, 2, 1, 1)
            });
        }
        #endregion




        #region Propriétés

        public string? Titre { get; set; } = string.Empty;
        public Personne? Auteur { get; set; }
        public DateTime DateCreation { get;set} = DateTime.Now;

        public (double Haut, double bas, double gauche, double droite) Marges { get; set; }

        public string PiedDePages =>
            $"{Auteur?.Prenom} {Auteur?.Nom ?? "Société XYZ"} - {Titre} - Crée le : {DateCreation:d}";

        #endregion

        #region Methodes publiques
        public static Document? CreerDepuisModele(string titreModele, Personne? auteur = null)
        {
            Document? doc = null;

            //recherche le modele ayant le titre souhaite
            Document? modele = Modeles.Find(m => m.Titre.ToLower() == titreModele.ToLower());

            //Si on a trouvé le modèle, on crée le document avec meme titre et marge
            if (modele != null)
            {
                doc = new Document
                {
                    Titre = modele.Titre,
                    Auteur = auteur,
                    Marges = modele.Marges
                };
            }
            return doc;
        #endregion
    }
}
