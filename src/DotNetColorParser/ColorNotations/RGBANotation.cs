using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    public class RGBANotation : ColorNotation
    {
        private readonly Regex _rgbaRE = new Regex(@"^\s*rgba(?:(?:\(\s*((?:(?<red>(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])))(?<space>[,\s]{1})\s*(?<green>(?:(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))))\k<space>\s*(?<blue>(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])\k<space>\s*(?<alpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+)))|(?:(?:(?<pred>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%(?<space>(?:,{1})|(?:\s*))\s*(?<pgreen>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<pblue>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<alpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+)))))\s*\))|(?:(?:\s{1}\s*((?:(?<red>(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])))(?<space>[,\s]{1})\s*(?<green>(?:(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))))\k<space>\s*(?<blue>(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])\k<space>\s*(?<alpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+)))|(?:(?:(?<pred>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%(?<space>(?:,{1})|(?:\s*))\s*(?<pgreen>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<pblue>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<alpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+))))))))\s*$");

        public override bool IsMatch(string str)
        {
            return _rgbaRE.IsMatch(str);
        }

        public override Color Parse(string str)
        {
            var match = _rgbaRE.Match(str);
            if (match.Success)
            {
                int red = 0, green = 0, blue = 0;
                var isByteNotation = match.Groups["red"].Success;
                var isPercentNotation = match.Groups["pred"].Success;
                if (isByteNotation || isPercentNotation)
                {
                    if (isByteNotation)
                    {
                        red = int.Parse(match.Groups["red"].Value);
                        green = int.Parse(match.Groups["green"].Value);
                        blue = int.Parse(match.Groups["blue"].Value);
                    }
                    else if (isPercentNotation)
                    {
                        red = (int)Math.Round((double.Parse(match.Groups["pred"].Value, CultureInfo.InvariantCulture) / 100) * 255, MidpointRounding.AwayFromZero);
                        green = (int)Math.Round((double.Parse(match.Groups["pgreen"].Value, CultureInfo.InvariantCulture) / 100) * 255, MidpointRounding.AwayFromZero);
                        blue = (int)Math.Round((double.Parse(match.Groups["pblue"].Value, CultureInfo.InvariantCulture) / 100) * 255, MidpointRounding.AwayFromZero);
                    }

                    var alpha = (int)Math.Round(double.Parse(match.Groups["alpha"].Value, CultureInfo.InvariantCulture) * 255, MidpointRounding.AwayFromZero);

                    return Color.FromArgb(alpha, red, green, blue);
                }
            }

            throw new InvalidColorNotationException();
        }
    }
}
