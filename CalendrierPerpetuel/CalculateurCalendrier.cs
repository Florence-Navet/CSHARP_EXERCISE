using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendrierPerpetuel;

internal static class CalculateurCalendrier
{
	/// <summary>
	/// Calcul de la date de Pâques pour une année donnée selon l'algorithme de Gauss modifié
	/// cf. https://math.stackexchange.com/questions/896954/decoding-gauss-easter-algorithm
	/// </summary>
	/// <param name="année">Année pour laquelle on veut obtenir la date de Pâques</param>
	/// <returns>Date de Pâques</returns>
	public static DateOnly CalculerDatePaques(int année)
	{
		int b = année - 1900;
		int c = année % 19;
		double d = Math.Floor((double)((7 * c + 1) / 19));
		double z = (11 * c + 4 - d) % 29;
		double f = Math.Floor((double)(b / 4));
		double g = (b + f + 31 - z) % 7;
		int Day = (int)(25 - z - g);

		int jour = (Day <= 0 ? Day + 31 : Day);
		int mois = (Day <= 0 ? 3 : 4);
		return new DateOnly(année, mois, jour);
	}

	/// <summary>
	/// Calcule les dates des changements de saisons pour une année donnée
	/// en utilisant une méthode approximative d'interpolation
	/// </summary>
	/// <param name="année">Année pour laquelle on veut obtenir les date de changements de saisons</param>
	/// <returns>Tuple des dates de début de printemps, été, automne et hiver</returns>
	public static (DateOnly printemps, DateOnly été, DateOnly automne, DateOnly hiver) CalculerDatesDébutsSaisons(int année)
	{
		DateOnly[] tabSaisons = new DateOnly[4];

		int k = année - 2001;
		for (int n = 0; n < 8; n++)
		{
			double dk = k + 0.25E0 * n;
			double T = 0.21451814 + 0.99997862442e0 * dk
			+ 0.00642125 * Math.Sin(1.580244 + 0.0001621008 * dk)
			+ 0.00310650 * Math.Sin(4.143931 + 6.2829005032 * dk)
			+ 0.00190024 * Math.Sin(5.604775 + 6.2829478479 * dk)
			+ 0.00178801 * Math.Sin(3.987335 + 6.2828291282 * dk)
			+ 0.00004981 * Math.Sin(1.507976 + 6.2831099520 * dk)
			+ 0.00006264 * Math.Sin(5.723365 + 6.2830626030 * dk)
			+ 0.00006262 * Math.Sin(5.702396 + 6.2827383999 * dk)
			+ 0.00003833 * Math.Sin(7.166906 + 6.2827857489 * dk)
			+ 0.00003616 * Math.Sin(5.581750 + 6.2829912245 * dk)
			+ 0.00003597 * Math.Sin(5.591081 + 6.2826670315 * dk)
			+ 0.00003744 * Math.Sin(4.3918 + 12.56578830 * dk)
			+ 0.00001827 * Math.Sin(8.3129 + 12.56582984 * dk)
			+ 0.00003482 * Math.Sin(8.1219 + 12.56572963 * dk)
			- 0.00001327 * Math.Sin(-2.1076 + 0.33756278 * dk)
			- 0.00000557 * Math.Sin(5.549 + 5.7532620 * dk)
			+ 0.00000537 * Math.Sin(1.255 + 0.0033930 * dk)
			+ 0.00000486 * Math.Sin(19.268 + 77.7121103 * dk)
			- 0.00000426 * Math.Sin(7.675 + 7.8602511 * dk)
			- 0.00000385 * Math.Sin(2.911 + 0.0005412 * dk)
			- 0.00000372 * Math.Sin(2.266 + 3.9301258 * dk)
			- 0.00000210 * Math.Sin(4.785 + 11.5065238 * dk)
			+ 0.00000190 * Math.Sin(6.158 + 1.5774000 * dk)
			+ 0.00000204 * Math.Sin(0.582 + 0.5296557 * dk)
			- 0.00000157 * Math.Sin(1.782 + 5.8848012 * dk)
			+ 0.00000137 * Math.Sin(-4.265 + 0.3980615 * dk)
			- 0.00000124 * Math.Sin(3.871 + 5.2236573 * dk)
			+ 0.00000119 * Math.Sin(2.145 + 5.5075293 * dk)
			+ 0.00000144 * Math.Sin(0.476 + 0.0261074 * dk)
			+ 0.00000038 * Math.Sin(6.45 + 18.848689 * dk)
			+ 0.00000078 * Math.Sin(2.80 + 0.775638 * dk)
			- 0.00000051 * Math.Sin(3.67 + 11.790375 * dk)
			+ 0.00000045 * Math.Sin(-5.79 + 0.796122 * dk)
			+ 0.00000024 * Math.Sin(5.61 + 0.213214 * dk)
			+ 0.00000043 * Math.Sin(7.39 + 10.976868 * dk)
			- 0.00000038 * Math.Sin(3.10 + 5.486739 * dk)
			- 0.00000033 * Math.Sin(0.64 + 2.544339 * dk)
			+ 0.00000033 * Math.Sin(-4.78 + 5.573024 * dk)
			- 0.00000032 * Math.Sin(5.33 + 6.069644 * dk)
			- 0.00000021 * Math.Sin(2.65 + 0.020781 * dk)
			- 0.00000021 * Math.Sin(5.61 + 2.942400 * dk)
			+ 0.00000019 * Math.Sin(-0.93 + 0.000799 * dk)
			- 0.00000016 * Math.Sin(3.22 + 4.694014 * dk)
			+ 0.00000016 * Math.Sin(-3.59 + 0.006829 * dk)
			- 0.00000016 * Math.Sin(1.96 + 2.146279 * dk)
			- 0.00000016 * Math.Sin(5.92 + 15.720504 * dk)
			+ 0.00000115 * Math.Sin(23.671 + 83.9950108 * dk)
			+ 0.00000115 * Math.Sin(17.845 + 71.4292098 * dk);

			double JJD = 2451545 + T * 365.25;
			double S = année / 100.0 - 18.30;
			double TETUJ = (32.23 * S * S - 15) / 86400;
			JJD += 0.0003472222;
			JJD -= TETUJ;

			double A = Trunc(JJD + 0.5);
			if ((JJD >= 2299160.5) && (A >= 2299161)) // Calendrier grégorien
			{
				double X = Trunc((A - 1867216.25) / 36524.25);
				A += 1 + X - Trunc(X / 4);
			}
			double B = A + 1524;
			double C = Trunc((B - 122.1) / 365.25);
			double D = Trunc(365.25 * C);
			double F = Trunc((B - D) / 30.6001);

			int jour = (int)Trunc(B - D - Trunc(30.6001 * F));
			int mois = (int)(F < 13.5 ? Trunc(F - 1) : Trunc(F - 13));
			int an = (int)(mois >= 3 ? Trunc(C - 4716) : Trunc(C - 4715));
			DateOnly tmpDate = new DateOnly(an, mois, jour);

			if (tmpDate.Year == année)
				tabSaisons[n % 4] = tmpDate;
		}

		return (tabSaisons[0], tabSaisons[1], tabSaisons[2], tabSaisons[3]);
	}

	private static double Trunc(double x)
	{
		return (x > 0.0 ? Math.Floor(x) : Math.Ceiling(x));
	}

	public static void AfficherDatesDebutsSaisons(int annee)
	{

		string format = "ddd dd MMM yyyy";
		var fr = CultureInfo.GetCultureInfo("fr-FR");

		var saisons = CalculerDatesDébutsSaisons(annee);
		string entetes = $"""
	Dates de débuts de saisons de l'année {annee}
------------------------------------------------------
- printemps : {saisons.printemps.ToString(format, fr)}
- été : {saisons.été.ToString(format, fr)}
- automne : {saisons.automne.ToString(format, fr)}
- hiver : {saisons.hiver.ToString(format, fr)}
""";
		Console.WriteLine(entetes);


	}

	public static void CalculerJoursFériésFrançais(int annee)
	{
		var fr = CultureInfo.GetCultureInfo("fr-FR");
		string format = "ddd dd MMM";

		DateOnly paques = CalculerDatePaques(annee);

		var JourFeries = new List<(DateOnly date, string nom)>
		{
			(new DateOnly(annee, 1, 1), "Jour de l'an"),
			(paques, "Pâques"),
			(paques.AddDays(1),"lundi de Pâques"),
			(new DateOnly(annee, 5, 1), "Fête du travail"),
			(new DateOnly(annee, 5, 8), "Armistice 1945"),
			(paques.AddDays(39),"Ascension"),
			(paques.AddDays(49),"Pentecôte"),
			(paques.AddDays(50),"Lundi de Pentecôte"),
			(new DateOnly(annee, 7, 14), "Fête Nationale"),
			(new DateOnly(annee, 8, 15), "Assomption"),
			(new DateOnly(annee, 11, 1), "Toussaint"),
			(new DateOnly(annee, 11, 11), "Armistice 1918"),
			(new DateOnly(annee, 12, 25), "Noël"),
		};

		JourFeries.Sort((a, b) => a.date.CompareTo(b.date));


		Console.WriteLine($"Jours fériés de l'année {annee}");
		Console.WriteLine("----------------------------------------");


		foreach (var jf in JourFeries)
		{
			Console.WriteLine(
				$"{jf.date.ToString(format, fr),-12}:{jf.nom}");
		}
	}

	public static (DateTimeOffset heureEte, DateTimeOffset heureHiver)
		CalculerChangementsHeures(int annee)
	{
		DateOnly dernierDimancheMars = DernierDimanche(annee, 3);
		DateOnly dernierDimancheOctobre = DernierDimanche(annee, 10);

		DateTimeOffset passageHeureEte =
			new DateTimeOffset(
				dernierDimancheMars.Year,
				dernierDimancheMars.Month,
				dernierDimancheMars.Day,
				2, 0, 0,
				TimeSpan.FromHours(1));

		DateTimeOffset passageHeureHiver =
			new DateTimeOffset(
			dernierDimancheOctobre.Year,
			dernierDimancheOctobre.Month,
			dernierDimancheOctobre.Day,
			3, 0, 0,
			TimeSpan.FromHours(2)
			);

		return (passageHeureEte, passageHeureHiver);
	}

	private static DateOnly DernierDimanche(int annee, int mois)
	{
		DateOnly d = new DateOnly(annee, mois, DateTime.DaysInMonth(annee, mois));
		while (d.DayOfWeek != DayOfWeek.Sunday)
			d = d.AddDays(-1);
		return d;
	}

	public static void AfficherHeureEteHeureHiver(int annee)
	{
		var fr = CultureInfo.GetCultureInfo("fr-FR");
		string format = "ddd dd MMM HH:mm zzz";

		var ch = CalculateurCalendrier.CalculerChangementsHeures(annee);

		Console.WriteLine($"Changements d'heures de l'année {annee}");
		Console.WriteLine("--------------------------------------------------------");
		Console.WriteLine($"Heure d'été  : {ch.heureEte.ToString(format, fr)}");
		Console.WriteLine();
		Console.WriteLine($"Heure d'hiver: {ch.heureHiver.ToString(format, fr)}");
		Console.WriteLine("--------------------------------------------------------");
	}

	public static int SaisirAnnee(int min, int max)
	{
		bool repOk;
		int annee;
		do
		{
			Console.WriteLine($"Entrez un année {min} et {max} :");
			string? saisie = Console.ReadLine();
			repOk = int.TryParse(saisie, out annee) && annee >= min && annee <= max;


		} while (!repOk);

		return annee;
	}

	public static DateOnly VotreAnniversaire(int annee)
	{
		bool repOk;
		DateOnly date = default;
		string format = "dd/MM";
		var fr = CultureInfo.GetCultureInfo("fr-FR");

		do
		{
			Console.WriteLine($"Entrez votre date d'anniversaire au format (ex 25/12) : ");
			string? saisie = Console.ReadLine();
			repOk =
				DateOnly.TryParseExact(
					saisie,
					format,
					fr,
					DateTimeStyles.AllowWhiteSpaces,
					out DateOnly jm);

			if (!repOk)
			{
				Console.WriteLine("Erreur : format invalide.");
				continue;
			}
			try
			{
				date = new DateOnly(annee, jm.Month, jm.Day);
			}
			catch
			{
				repOk = false;
				Console.WriteLine("Erreur : date impossible pour cette année.");
			}


		} while (!repOk);

		return date;

	}

	public static void AfficherAnniversaire(int annee)
	{
		DateOnly anniversaire = VotreAnniversaire(annee);

		var fr = CultureInfo.GetCultureInfo("fr-FR");
		string jour = anniversaire.ToString("dddd", fr);

      Console.WriteLine(
			$"En {annee}, votre anniversaire sera un {jour}.");
	}

}
