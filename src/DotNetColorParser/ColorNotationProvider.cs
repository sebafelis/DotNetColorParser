using DotNetColorParser.ColorNotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotNetColorParser
{
    /// <inheritdoc/>
    public class ColorNotationProvider : IColorNotationProvider
    {
        readonly Dictionary<int, IColorNotation> _colorNotations;

        /// <summary>
        /// Create ColorNotationProvider object.
        /// </summary>
        /// <param name="autoConfigure">When <c>true</c> then automatically add all standard implementations of IColorNotation interface.</param>
        public ColorNotationProvider(bool autoConfigure = false)
        {
            _colorNotations = new Dictionary<int, IColorNotation>();

            if (autoConfigure)
            {
                Add(new HexRGBANotation());
                Add(new RGBNotation());
                Add(new RGBANotation());
                Add(new HSLNotation());
                Add(new HSLANotation());
                Add(new HSVNotation());
#if NETSTANDARD2_1 || NET45
                Add(new KnownColorNameNotation());
#endif
            }
        }

        /// <inheritdoc/>
        public int Count => _colorNotations.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add color notation
        /// </summary>
        /// <param name="item">Color notation object</param>
        /// <remarks>
        /// In most case only one object implement specific class can be add to provider.
        /// </remarks>
        public void Add(IColorNotation item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _colorNotations.Add(item.GetHashCode(), item);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _colorNotations.Clear();
        }

        /// <summary>
        /// Check is color notation add to provider. 
        /// </summary>
        /// <remarks>
        /// In most case only one object implement specific class can be add to provider.
        /// </remarks>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(IColorNotation item)
        {
            return _colorNotations.ContainsKey(item.GetHashCode());
        }

        /// <inheritdoc/>
        public void CopyTo(IColorNotation[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Rank > 1)
                throw new ArgumentException("array is multidimensional.");
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Not enough elements after index in the destination array.");

            var i = 0;
            foreach (var item in this)
            {
                array.SetValue(item, i + arrayIndex);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection order by <see cref="IColorNotation.Order"/>.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IColorNotation> GetEnumerator()
        {
            return _colorNotations.Select(s => s.Value).OrderBy(o => o.Order).GetEnumerator();
        }

        /// <summary>
        /// Remove color notation object.
        /// </summary>
        /// <remarks>
        /// Object is finding by them hash code.
        /// </remarks>
        /// <param name="item"></param>
        /// <returns><c>true</c> if object was found and remove. Otherwise <c>false</c>.</returns>
        public bool Remove(IColorNotation item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return _colorNotations.Remove(item.GetHashCode());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
