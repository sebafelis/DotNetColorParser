using DotNetColorParser.Exceptions;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    /// <summary>
    /// Color notation with <c>hsv</c> prefix expressed in HSV color space. Allows the following syntaxes:
    /// <list type="bullet">
    /// <item>
    /// <description><c>hsv(180,255,255)</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv 180,255,255</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv 180 255 255</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv(180 .5 .5)</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv(180, 100%, 95.4%)</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv 180 100% 95.4%</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv(180dec 100% 50%)</c></description>
    /// </item>
    /// <item>
    /// <description><c>hsv 180dec 100% 95.4%</c></description>
    /// </item>
    /// </list>
    /// </summary>
    public class HSVNotation : ColorNotation
    {
        private readonly Regex _hsvRE = new Regex(@"^\s*hsv(?:(?:\(\s*(?:(?:(?<huedeg>(?:(?:[12]?[1-9]?\d)|[12]0\d|(?:3[0-5]\d))(?:\.\d+)?)|(?:\.\d+))(?:deg)?|(?<hueturn>0|0?\.\d+)turn|(?<huegrad>0|0?\.\d+)grad|(?<huerad>(?:[0-6](?:\.\d+)?)|(?:\.\d+))rad)(?<space>[,\s]{1})\s*(?<saturation>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?\k<space>\s*(?<value>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?\s*\))|(?:\s+(?:(?:(?:(?<huedeg>(?:[12]?[1-9]?\d)|[12]0\d|(?:3[0-5]\d))(?:\.\d+)?)|(?:\.\d+))(?:deg)?|(?<hueturn>0|0?\.\d+)turn|(?<huerad>(?:[0-6](?:\.\d+)?)|(?:\.\d+))rad)(?<space>[,\s]{1})\s*(?<saturation>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?\k<space>\s*(?<value>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?))\s*$");

        /// <inheritdoc/>
        public override bool IsMatch(string str)
        {
            return _hsvRE.IsMatch(str);
        }

        /// <inheritdoc/>
        public override Color Parse(string str)
        {
            var match = _hsvRE.Match(str);
            if (match.Success)
            {
                double hue, saturation, value;
                var huedeg = match.Groups["huedeg"];
                if (huedeg.Success)
                {
                    hue = double.Parse(huedeg.Value, CultureInfo.InvariantCulture);
                }
                else
                {
                    var huerad = match.Groups["huerad"];
                    if (huerad.Success)
                    {
                        hue = double.Parse(huerad.Value, CultureInfo.InvariantCulture).RadiansToDegrees();
                    }
                    else
                    {
                        var hueturn = match.Groups["hueturn"];
                        if (hueturn.Success)
                        {
                            hue = double.Parse(hueturn.Value, CultureInfo.InvariantCulture).TurnsToDegrees();
                        }
                        else
                        {
                            var huegrad = match.Groups["huegrad"];
                            if (huegrad.Success)
                            {
                                hue = double.Parse(huegrad.Value, CultureInfo.InvariantCulture).GradToDegrees();
                            }
                            else
                            {
                                throw new InvalidColorNotationException();
                            }
                        }
                    }
                }

                saturation = double.Parse(match.Groups["saturation"].Value, CultureInfo.InvariantCulture);
                value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);

                return ColorConverter.FromHSV(hue, saturation, value);
            }

            throw new InvalidColorNotationException();
        }
    }
}
