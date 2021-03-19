using DotNetColorParser.ColorNotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotNetColorParser
{
    /// <summary>
    /// Object provides color notations used by <see cref="DotNetColorParser.ColorParser"/>
    /// </summary>
    public class ColorNotationProvider : IColorNotationProvider
    {
        readonly Dictionary<int, IColorNotation> _colorNotations;

        /// <summary>
        /// Create ColorNotationProvider object
        /// </summary>
        /// <param name="autoConfigure">When <c>true</c> then add all standard implementations of IColorNotation interface.</param>
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
                Add(new KnownColorNameNotation());
            }
        }

        public int Count => _colorNotations.Count;

        public bool IsReadOnly => false;

        public void Add(IColorNotation item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _colorNotations.Add(item.GetHashCode(), item);
        }

        public void Clear()
        {
            _colorNotations.Clear();
        }

        public bool Contains(IColorNotation item)
        {
            return _colorNotations.ContainsKey(item.GetHashCode());
        }

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

        public IEnumerator<IColorNotation> GetEnumerator()
        {
            return _colorNotations.Select(s => s.Value).OrderBy(o => o.Order).GetEnumerator();
        }

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
