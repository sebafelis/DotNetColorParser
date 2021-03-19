using System.Drawing;

namespace DotNetColorParser
{
    public interface IColorNotation
    {
        bool IsMatch(string str);

        Color Parse(string str);

        int Order { get; }
    }
}
