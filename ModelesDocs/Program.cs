namespace ModelesDocs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var auteurs = new Personne[3];
            auteurs[1] = new Personne { Nom = "Dupnt", Prenom = "Jean"  };
            auteurs[2] = new Personne { Nom = "Martin", Prenom = "Sophie"  };

            var nomModeles = new string[]
            {
                "Modèle A",
                "Modèle B",
                "Modèle C" // ce modèle n'existe pas
            };

            for (int i = 0; i < auteurs.Length; i++)
            {
                Document? doc = Document.CreerDepuisModele(nomModeles[i], auteurs[i]);

                if (doc == null)
                {
                    Console.WriteLine($"Aucun modèle trouvé avec le titre {nomModeles[i]}\n");
                    continue;
                }

                Console.WriteLine($"""
                    Document créé :
                    Pied de page : {doc.PiedDePages}
                    Marges : H = {doc.Marges.Haut} cm, B = {doc.Marges.bas} cm, G = {doc.Marges.gauche} cm, D = {doc.Marges.droite} cm
                    """);
            }
        }
    }
}
