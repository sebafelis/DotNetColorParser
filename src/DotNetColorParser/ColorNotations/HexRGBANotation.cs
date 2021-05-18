using DotNetColorParser.Exceptions;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    /// <summary>
    /// Hexadecimal color notation expressed in RBGA color space. Support following syntaxes:
    /// <list type="bullet">
    /// <item>
    /// <description>#RGB</description>
    /// </item>
    /// <item>
    /// <description>#RRGGBB</description>
    /// </item>
    /// <item>
    /// <description>#RRGGBBAA</description>
    /// </item>
    /// </list>
    /// Where:
    /// <c>R</c>, <c>G</c>, <c>B</c>, <c>A</c> is character between 0-9 and A-F (case insensitive).
    /// # is optional.
    /// </summary>
    public class HexRGBANotation : ColorNotation
    {
        private static readonly Regex _hexrgbaRE = new Regex(@"^\s*#?((?<hex3>([0-9A-F]{3}))|(?<hex4>([0-9A-F]{4}))|(?<hex6>([0-9A-F]{2}){3})|(?<hex8>([0-9A-F]{2}){4}))\s*$", RegexOptions.IgnoreCase);

        /// <inheritdoc/>
        public override bool IsMatch(string str)
        {
            return _hexrgbaRE.IsMatch(str);
        }

        /// <inheritdoc/>
        public override Color Parse(string str)
        {
            var match = _hexrgbaRE.Match(str);
            if (match.Success)
            {
                return ColorConverter.FromHex(str);
            }

            throw new InvalidColorNotationException();
        }
    }
}
