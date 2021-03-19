using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    public class HexRGBANotation : ColorNotation
    {
        private static readonly Regex _hexrgbaRE = new Regex(@"^\s*#?((?<hex3>([0-9A-F]{3}))|(?<hex4>([0-9A-F]{4}))|(?<hex6>([0-9A-F]{2}){3})|(?<hex8>([0-9A-F]{2}){4}))\s*$", RegexOptions.IgnoreCase);

        public override bool IsMatch(string str)
        {
            return _hexrgbaRE.IsMatch(str);
        }

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
