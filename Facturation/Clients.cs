using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation
{
    public abstract class Client
    {

        private static int _compteur;

        public int Id { get; }
        public virtual string NomComplet { get; protected set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;

        public Client()
        {
            Id = ++_compteur;
        }
        public override string ToString()
        {
            return $"""
			Référence : {Id}
			{NomComplet}
			Adresse : {Adresse}
			""";
        }

    }

    public enum Civilités { Mme, Mr };
    public class Particulier : Client
    {
    

        public Civilités Civilité { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public override string NomComplet => $"{Civilité} {Nom} {Prenom}";


        public Particulier(Civilités civilité, string nom, string prenom)
        {
            Civilité = civilité;
            Nom = nom;
            Prenom = prenom;
        }


    }

    public class Entreprise : Client
    {
 

        public string RaisonSociale { get; set; }
        public long SIRET { get; set; }
        public override string NomComplet => $"Société {RaisonSociale}";

        public Entreprise(string raisonSociale, long siret)
        {
            RaisonSociale = raisonSociale;
            SIRET = siret;
        }
        public override string ToString()
        {
            return $"""
			{base.ToString()}
			SIRET : {SIRET:### ### ### #####}
			""";
        }
    }
}
