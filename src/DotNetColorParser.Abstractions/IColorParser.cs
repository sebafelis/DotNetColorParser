using System.Drawing;

namespace DotNetColorParser
{
    public interface IColorParser
    {
        Color ParseColor(string value);
    }
}