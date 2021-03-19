using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DotNetColorParser
{
    public interface IColorNotation
    {
        bool IsMatch(string str);

        Color Parse(string str);

        int Order { get; }
    }
}
