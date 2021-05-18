using System.Drawing;

namespace DotNetColorParser
{
    /// <summary>
    /// Recognize and parse specify color notation.
    /// </summary>
    public interface IColorNotation
    {
        /// <summary>
        /// Checks that an input value matches a notation pattern.
        /// </summary>
        /// <param name="str">Color notify as a string.</param>
        /// <returns><c>true</c> if <paramref name="str"/> match a pattern</returns>
        bool IsMatch(string str);

        /// <summary>
        /// Parse the input string in correct notation and create <see cref="System.Drawing.Color"/> object.
        /// </summary>
        /// <param name="str">Color notify as a string.</param>
        /// <exception cref="Exceptions.InvalidColorNotationException">
        /// When string was recognized as match but parse failed.
        /// </exception>
        Color Parse(string str);

        /// <summary>
        /// Matching order.  
        /// </summary>
        /// <remarks>
        /// Default value is <c>0</c>. <c>0</c> is good if matching order is has no matter for result.
        /// </remarks>
        int Order { get; }
    }
}
