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
        /// <param name="value">Color noted as a string.</param>
        /// <returns>Color write in ARGB color space.</returns>
        /// <exception cref="Exceptions.UnkownColorNotationException">When color notation is not recognize.</exception>
        /// <exception cref="Exceptions.InvalidColorNotationException">When color notation is recognize as match but can not be parse correctly.</exception>
        Color ParseColor(string value);

        /// <summary>
        /// Try parse the input string and create <see cref="System.Drawing.Color"/> object.
        /// </summary>       
        /// <param name="value">Color notify as a string.</param>
        /// <param name="color">An output color.</param>
        /// <returns><c>true</c> if color can be parse, otherwise <c>false</c>.</returns>
        bool TryParseColor(string value, out Color color);
    }
}