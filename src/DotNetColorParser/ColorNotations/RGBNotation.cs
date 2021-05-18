using DotNetColorParser.Exceptions;
using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    /// <summary>
    /// Color notation with <c>rgb</c> prefix expressed in RBG color space. This notation allows strings like:
    /// <list type="bullet">
    /// <item>
    /// <description><c>rgb(255,255,255)</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb 255,255,255</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb 255 255 255</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb(255 255 255)</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb(100%, 100%, 95.4%)</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb 100% 100% 95.4%</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb(100%100%95.4%)</c></description>
    /// </item>
    /// <item>
    /// <description><c>rgb 100%100%95.4%</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// Recognize all syntax versions with <c>rgb</c> prefix allowed by CSS3 and more.
    /// </remarks>
    public class RGBNotation : ColorNotation
    {
        private readonly Regex _rgbRE = new Regex(@"^\s*rgb(?:(?:\(\s*((?:(?<red>(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])))(?<space>[,\s]{1})\s*(?<green>(?:(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))))\k<space>\s*(?<blue>(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))|(?:(?:(?<pred>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%(?<space>(?:,{1})|(?:\s*))\s*(?<pgreen>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<pblue>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%)))\s*\))|(?:(?:\s{1}\s*((?:(?<red>(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5])))(?<space>[,\s]{1})\s*(?<green>(?:(?:(?:(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))))\k<space>\s*(?<blue>(?:1?[1-9]?\d)|10\d|(?:2[0-4]\d)|25[0-5]))|(?:(?:(?<pred>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%(?<space>(?:,{1})|(?:\s*))\s*(?<pgreen>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%\k<space>\s*(?<pblue>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%))))))\s*$", RegexOptions.IgnoreCase);

        /// <inheritdoc/>
        public override bool IsMatch(string str)
        {
            return _rgbRE.IsMatch(str);
        }

        /// <inheritdoc/>
        public override Color Parse(string str)
        {
            var match = _rgbRE.Match(str);
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

                    return Color.FromArgb(red, green, blue);
                }
            }

            throw new InvalidColorNotationException();
        }
    }
}
