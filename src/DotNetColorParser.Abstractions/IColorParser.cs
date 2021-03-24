using System.Drawing;

namespace DotNetColorParser
{
    /// <summary>
    /// Interface designed for the DotNetColorParser library
    /// </summary>
    public interface IColorParser
    {
        /// <summary>
        /// Parse the input string and create <see cref="System.Drawing.Color"/> object.
        /// </summary>
        /// <param name="value">Color notify as a string.</param>
        Color ParseColor(string value);
    }
}