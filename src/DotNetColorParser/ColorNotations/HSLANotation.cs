using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DotNetColorParser.ColorNotations
{
    public class HSLANotation : ColorNotation
    {
        private readonly Regex _hslaRE = new Regex(@"^\s*hsla(?:(?:\(\s*(?:(?:(?<huedeg>(?:(?:[12]?[1-9]?\d)|[12]0\d|(?:3[0-5]\d))(?:\.\d+)?)|(?:\.\d+))(?:deg)?|(?<hueturn>0|0?\.\d+)turn|(?<huegrad>0|0?\.\d+)grad|(?<huerad>(?:[0-6](?:\.\d+)?)|(?:\.\d+))rad)(?<space>[,\s]{1})\s*(?<saturation>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?\k<space>\s*(?<lightness>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?(?:\k<space>|\s*\/)\s*(?:(?:(?<nalpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+)))|(?:(?<palpha>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?))\s*\))|(?:\s+(?:(?:(?:(?<huedeg>(?:[12]?[1-9]?\d)|[12]0\d|(?:3[0-5]\d))(?:\.\d+)?)|(?:\.\d+))(?:deg)?|(?<hueturn>0|0?\.\d+)turn|(?<huerad>(?:[0-6](?:\.\d+)?)|(?:\.\d+))rad)(?<space>[,\s]{1})\s*(?<saturation>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?\k<space>\s*(?<lightness>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?(?:\k<space>|\s*\/)\s*(?:(?:(?<nalpha>(?:1(?:\.0+)?)|(?:0(?:\.\d*)?)|(?:\.\d+)))|(?:(?<palpha>(?:(?:[1-9]?\d(?:\.\d+)?)|100|(?:\.\d+)))%?))))\s*$");

        public override bool IsMatch(string str)
        {
            return _hslaRE.IsMatch(str);
        }

        public override Color Parse(string str)
        {
            var match = _hslaRE.Match(str);
            if (match.Success)
            {
                double hue, saturation, lightness, alpha;
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
                lightness = double.Parse(match.Groups["lightness"].Value, CultureInfo.InvariantCulture);

                var nalpha = match.Groups["nalpha"];
                if (nalpha.Success)
                {
                    alpha = double.Parse(nalpha.Value, CultureInfo.InvariantCulture);
                }
                else
                {
                    alpha = (double.Parse(match.Groups["palpha"].Value, CultureInfo.InvariantCulture) / 100);
                }

                return ColorConverter.FromHSLA(hue, saturation, lightness, alpha);
            }

            throw new InvalidColorNotationException();
        }
    }
}
