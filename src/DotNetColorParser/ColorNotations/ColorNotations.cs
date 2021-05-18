using System.Drawing;

namespace DotNetColorParser.ColorNotations
{
    /// <summary>
    /// Color notation abstraction implementing default <see cref="ColorNotation.Equals(object)"/>, <see cref="ColorNotation.GetHashCode()"/> and <see cref="ColorNotation.Order"/>.
    /// </summary>
    public abstract class ColorNotation : IColorNotation
    {
        /// <summary>
        /// Used by <see cref="ColorNotationProvider"/> to not duplicate the notation.
        /// </summary>
        /// <remarks>
        /// If all instances of your class has always the same output for specify input then you should left this implementation.
        /// Otherwise if class is customizable (e.g. by constructor parameters) you should make this method dependent on these customizations.
        /// </remarks>
        /// <param name="obj"><inheritdoc cref="System.Type.Equals(object)" path="/param"/></param>
        /// <returns><inheritdoc cref="System.Type.Equals(object)" path="/returns"/></returns>
        public override bool Equals(object obj)
        {
            return this.GetType().Equals(obj.GetType());
        }

        /// <summary>
        /// Used by <see cref="ColorNotationProvider"/> to not duplicate the notation.
        /// </summary>
        /// <remarks>
        /// If all instances of your class has always the same output for specify input then you should left this implementation.
        /// Otherwise if class is customizable (e.g. by constructor parameters) you should make this method dependent on these customizations.
        /// </remarks>
        /// <returns><inheritdoc cref="System.Type.GetHashCode" path="/returns"/></returns>
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        /// <inheritdoc/>
        public abstract bool IsMatch(string str);

        /// <inheritdoc/>
        public abstract Color Parse(string str);
        
        /// <inheritdoc/>
        public virtual int Order => 0;
    }
}
