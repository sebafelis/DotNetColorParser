using System;

namespace DotNetColorParser
{
    internal static class NumericExtensions
    {
        /// <summary>
        /// Convert Radians to Degrees.
        /// </summary>
        /// <param name="val">The value in radians convert to degrees</param>
        /// <returns>The value in degrees</returns>
        public static double RadiansToDegrees(this double val)
        {
            return Math.Round((180 / Math.PI) * val, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Convert Turns to Degrees.
        /// </summary>
        /// <param name="val">The value in turns convert to degrees</param>
        /// <returns>The value in degrees</returns>
        public static double TurnsToDegrees(this double val)
        {
            return Math.Round(360 * val, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Convert Gradus to Degrees.
        /// </summary>
        /// <param name="val">The value in gradus convert to degrees</param>
        /// <returns>The value in degrees</returns>
        public static double GradToDegrees(this double val)
        {
            return val * 0.9;
        }
    }
}
