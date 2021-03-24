using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DotNetColorParser.ColorNotations
{
    /// <summary>
    /// Color notation based on defined by KnownColor class color keywords corresponding specify RGB colors.
    /// </summary>
    /// <remarks>Notation not supported in .Net Standard 2.0 version now.</remarks>
    public class KnownColorNameNotation : ColorNotation, IColorNotation
    {
        private static IEnumerable<string> GetKnowColorNames()
        {
#if NETSTANDARD2_1 || NET45
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                yield return knowColor.ToString();
            }
#else
            throw new NotImplementedException();
#endif
        }

        private readonly Lazy<IEnumerable<string>> _knowKolors = new Lazy<IEnumerable<string>>(() => GetKnowColorNames());

        private string CleanString(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return str.Trim().ToLowerInvariant();
        }

        /// <inheritdoc/>
        public override bool IsMatch(string str)
        {
            return _knowKolors.Value.Contains(CleanString(str), StringComparer.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override Color Parse(string str)
        {
#if NETSTANDARD2_1 || NET45
            var color = Color.FromName(CleanString(str));
            if (!color.IsKnownColor)
            {
                throw new InvalidColorNotationException();
            }
            return color;
#else
            throw new NotImplementedException();
#endif
        }

        /// <inheritdoc/>
        /// <value>Value is equal 100 because this notation should be match as last of from the standard notations.</value>
        public override int Order => base.Order + 100;
    }
}
