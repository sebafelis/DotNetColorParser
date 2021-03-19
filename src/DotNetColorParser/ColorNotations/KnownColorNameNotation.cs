using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    public class KnownColorNameNotation : ColorNotation, IColorNotation
    {
        private readonly Regex _nameRE = new Regex(@"^\s*([A-Za-z]+)+\s*$");

        private static IEnumerable<string> GetKnowColorNames()
        {
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                yield return knowColor.ToString();
            }
        }

        private Lazy<IEnumerable<string>> _knowKolors = new Lazy<IEnumerable<string>>(() => GetKnowColorNames());

        private string CleanString(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return str.Trim().ToLowerInvariant();
        }


        public override bool IsMatch(string str)
        {
            return _knowKolors.Value.Contains(CleanString(str), StringComparer.InvariantCultureIgnoreCase);
        }

        public override Color Parse(string str)
        {
            var color = Color.FromName(CleanString(str));
            if (!color.IsKnownColor)
            {
                throw new InvalidColorNotationException();
            }
            return color;
        }

        public override int Order => base.Order + 100;
    }
}
