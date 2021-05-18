using DotNetColorParser.Exceptions;
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

        /// <inheritdoc cref="ParseColor(string)"/>
        public static Color Parse(string value)
        {
            return _colorParser.Value.ParseColor(value);
        }

        /// <summary>
        /// <inheritdoc cref="ParseColor(string)" path="/summary"/> This method use only one color notation specify as <typeparamref name="T"/>.
        /// </summary>
        /// <inheritdoc cref="ParseColor(string)" path="/returns"/>
        /// <inheritdoc cref="ParseColor(string)" path="/param"/>
        /// <inheritdoc cref="ParseColor(string)" path="/exception"/>
        public static Color Parse<T>(string value) where T : IColorNotation
        {
            var provider = new ColorNotationProvider(false)
            {
                Activator.CreateInstance<T>()
            };
            return new ColorParser(provider).ParseColor(value);
        }

        /// <inheritdoc cref="TryParseColor(string, out Color)"/>
        public static bool TryParse(string value, out Color color)
        {
            return _colorParser.Value.TryParseColor(value, out color);
        }

        /// <summary>
        /// <inheritdoc cref="TryParseColor(string, out Color)" path="/summary"/> This method use only one color notation specify as <typeparamref name="T"/>.
        /// </summary>
        /// <inheritdoc cref="TryParseColor(string, out Color)" path="/returns"/>
        /// <inheritdoc cref="TryParseColor(string, out Color)" path="/param"/>
        public static bool TryParse<T>(string value, out Color color) where T : IColorNotation
        {
            var provider = new ColorNotationProvider(false)
            {
                Activator.CreateInstance<T>()
            };
            return new ColorParser(provider).TryParseColor(value, out color);
        }

        private readonly IColorNotationProvider _colorNotationProvider;

        /// <summary>
        /// Create ColorParser object.
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool TryParseColor(string value, out Color color)
        {
            try
            {
                color = ParseColor(value);
                return true;
            }
            catch (Exception ex) when (ex is InvalidColorNotationException || ex is UnkownColorNotationException)
            {
                color = Color.Empty;
                return false;
            }
        }
    }
}
