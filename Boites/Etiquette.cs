using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
   public enum Couleurs { Blanc, Bleu, Vert, Jaune, Orange, Rouge, Marron }

   public enum Formats { XS, S, M, L, XL }
   internal class Etiquette
   {
      public required string Texte { get; init; } = string.Empty;

      public required Couleurs couleur { get; init; }

      public required Formats format { get; init; }

   }
}
