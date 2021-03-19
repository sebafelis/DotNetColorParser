using System.Drawing;

namespace DotNetColorParser.ColorNotations
{
    public abstract class ColorNotation : IColorNotation
    {
        public override bool Equals(object obj)
        {
            return this.GetType().Equals(obj.GetType());
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        public abstract bool IsMatch(string str);

        public abstract Color Parse(string str);

        public virtual int Order => 0;
    }
}
