using System;
using System.Drawing;

namespace DotNetColorParser
{
    /// <summary>
    /// Converts string to color usable by .NET.
    /// </summary>
    public class ColorParser : IColorParser
    {

        private static Lazy<IColorNotationProvider> _defaultProvider = new Lazy<IColorNotationProvider>(() => new ColorNotationProvider(true));

        /// <summary>
        /// Default <see cref="ColorNotationProvider"/> for <see cref="ColorParser"/>.
        /// </summary>
        /// <remarks>
        /// Is use by <seealso cref="ColorParser"/> static methods and <see cref="ColorParser"/> instance with null 
        /// </remarks>
        public static IColorNotationProvider DefaultProvider
        {
            get
            {
                return _defaultProvider.Value;
            }
            set
            {
                _defaultProvider = new Lazy<IColorNotationProvider>(() => value);
                _colorParser = new Lazy<ColorParser>();
            }
        }

        private static Lazy<ColorParser> _colorParser = new Lazy<ColorParser>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        /// <exception cref="DotNetColorParser.UnkownColorNotationException">
        /// Throw if color notation is unknown or 
        /// </exception>
        /// <exception cref="DotNetColorParser.InvalidColorNotationException">
        /// Throw if string was recognized as match but parse failed.
        /// </exception>
        public static Color Parse(string value)
        {
            return _colorParser.Value.ParseColor(value);
        }

        /// <summary>
        /// Convert the color saved as a string to <see cref="System.Drawing.Color"/> object. 
        /// Allowed string notation is defined by attribute <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Allow color notation</typeparam>
        /// <param name="value">Color saved as a string</param>
        /// <returns>Color write in ARGB color space.</returns>
        public static Color Parse<T>(string value) where T : IColorNotation
        {
            var provider = new ColorNotationProvider(false)
            {
                Activator.CreateInstance<T>()
            };
            return new ColorParser(provider).ParseColor(value);
        }

        private readonly IColorNotationProvider _colorNotationProvider;

        /// <summary>
        /// Create ColorParser object
        /// </summary>
        /// <param name="provider">Color notations provider</param>
        public ColorParser(IColorNotationProvider provider)
        {
            if (provider is null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _colorNotationProvider = provider;
        }

        /// <summary>
        /// Convert the color saved as a string to <see cref="System.Drawing.Color"/> object.
        /// Allowed string notations are defined in Color Notation Provider passed to constructor <see cref="DotNetColorParser"/>
        /// </summary>
        /// <param name="value">Color write as string</param>
        /// <returns>Color write in ARGB color space.</returns>
        public Color ParseColor(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            foreach (var colorNotation in _colorNotationProvider)
            {
                if (colorNotation.IsMatch(value))
                {
                    return colorNotation.Parse(value);
                }
            }

            throw new UnkownColorNotationException();
        }
    }
}
