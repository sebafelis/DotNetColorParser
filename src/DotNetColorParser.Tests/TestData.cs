using System.Collections.Generic;

namespace DotNetColorParser.Tests
{
    #region KnowColor

    public class ValidKnowColorNameTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "red" };
            yield return new object[] { " blue" };
            yield return new object[] { "Green" };
            yield return new object[] { "pURPLe" };
            yield return new object[] { " YeLlow " };
            yield return new object[] { "GREEN" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidKnowColorNameWithRBGAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "red", 255, 0, 0, 255 };
            yield return new object[] { " blue", 0, 0, 255, 255 };
            yield return new object[] { "Green", 0, 128, 0, 255 };
            yield return new object[] { "pURPLe", 128, 0, 128, 255 };
            yield return new object[] { " YeLlow ", 255, 255, 0, 255 };
            yield return new object[] { "GREEN", 0, 128, 0, 255 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidKnowColorNameTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { "5pURPURe" };
            yield return new object[] { "red4" };
            yield return new object[] { "#green" };
            yield return new object[] { "dark green" };
            yield return new object[] { "dark.blue" };
            yield return new object[] { "rgb 23" };
            yield return new object[] { "rgb(255,0,0)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region Hex

    public class ValidHexTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "#ffffff" };
            yield return new object[] { "#FFFFFF" };
            yield return new object[] { "AB00AB" };
            yield return new object[] { "e08048" };
            yield return new object[] { "#fff" };
            yield return new object[] { "333" };
            yield return new object[] { " 333 " };
            yield return new object[] { " #333" };
            yield return new object[] { " #666666" };
            yield return new object[] { " 333AAA" };
            yield return new object[] { " #66666688" };
            yield return new object[] { " 333AAA88" };
            yield return new object[] { " #6668" };
            yield return new object[] { " 3338" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidHexWithRGBAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "#ffffff", 255, 255, 255, 255 };
            yield return new object[] { "#FFFFFF", 255, 255, 255, 255 };
            yield return new object[] { "AB00AB", 171, 0, 171, 255 };
            yield return new object[] { "e08048", 224, 128, 72, 255 };
            yield return new object[] { "#fff", 255, 255, 255, 255 };
            yield return new object[] { "333", 51, 51, 51, 255 };
            yield return new object[] { " 333 ", 51, 51, 51, 255 };
            yield return new object[] { " #333", 51, 51, 51, 255 };
            yield return new object[] { " #666666", 102, 102, 102, 255 };
            yield return new object[] { " 333AAA", 51, 58, 170, 255 };
            yield return new object[] { " #66666688", 102, 102, 102, 136 };
            yield return new object[] { " 333AAA88", 51, 58, 170, 136 };
            yield return new object[] { " #6668", 102, 102, 102, 136 };
            yield return new object[] { " 3338", 51, 51, 51, 136 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidHexTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { " # ffffff" };
            yield return new object[] { "#FFGFFF" };
            yield return new object[] { "-1B00AB" };
            yield return new object[] { "e0\\048" };
            yield return new object[] { "#fkf" };
            yield return new object[] { "/ffffff" };
            yield return new object[] { "-000000 " };
            yield return new object[] { "(000000)" };
            yield return new object[] { "AB?" };
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { "      " };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region RGB

    public class ValidRGBTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rgb(255,255,255)" };
            yield return new object[] { " rgb(255,255,255) " };
            yield return new object[] { " rgb(255,255,255)" };
            yield return new object[] { " rgb(128,0,23)" };
            yield return new object[] { "rgb(0,0,0)" };
            yield return new object[] { "rgb( 255, 255, 255 )" };
            yield return new object[] { "rgb(255, 255,255 )" };
            yield return new object[] { "rgb(255, 255, 255)" };
            yield return new object[] { "rgb( 255, 255, 255 )" };
            yield return new object[] { "rgb(2,42,14)" };
            yield return new object[] { "rgb 255,255,255" };
            yield return new object[] { " rgb 255 255 255 " };
            yield return new object[] { " rgb 255,255,255" };
            yield return new object[] { " rgb 128, 0, 23" };
            yield return new object[] { "rgb 0 0 0" };
            yield return new object[] { "rgb  255 255 255  " };
            yield return new object[] { "rgb 255, 255,255 " };
            yield return new object[] { "rgb(100%, 50%, 25%)" };
            yield return new object[] { "rgb(100%, 50%, 25%)" };
            yield return new object[] { "rgb(100%, 50%, 25% )" };
            yield return new object[] { "rgb 90.5%,50.3%,25.56%" };
            yield return new object[] { "rgb 100%, 50%, 25%" };
            yield return new object[] { "rgb 0.444%, 0.7856%, 0.4543%" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidRGBWithRGBAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rgb(255,255,255)", 255, 255, 255, 255 };
            yield return new object[] { " rgb(255,255,255) ", 255, 255, 255, 255 };
            yield return new object[] { " rgb(255,255,255)", 255, 255, 255, 255 };
            yield return new object[] { " rgb(128,0,23)", 128, 0, 23, 255 };
            yield return new object[] { "rgb(0,0,0)", 0, 0, 0, 255 };
            yield return new object[] { "rgb( 255, 255, 255 )", 255, 255, 255, 255 };
            yield return new object[] { "rgb(255, 255,255 )", 255, 255, 255, 255 };
            yield return new object[] { "rgb(255, 255, 255)", 255, 255, 255, 255 };
            yield return new object[] { "rgb( 255, 255, 255 )", 255, 255, 255, 255 };
            yield return new object[] { "rgb(255,255,255) ", 255, 255, 255, 255 };
            yield return new object[] { "rgb(2,42,14)", 2, 42, 14, 255 };
            yield return new object[] { "rgb 255,255,255", 255, 255, 255, 255 };
            yield return new object[] { " rgb 255 255 255 ", 255, 255, 255, 255 };
            yield return new object[] { " rgb 255,255,255", 255, 255, 255, 255 };
            yield return new object[] { " rgb 128, 0, 23", 128, 0, 23, 255 };
            yield return new object[] { "rgb 0 0 0", 0, 0, 0, 255 };
            yield return new object[] { "rgb  255 255 255  ", 255, 255, 255, 255 };
            yield return new object[] { "rgb 255, 255,255 ", 255, 255, 255, 255 };
            yield return new object[] { "rgb(100%, 50%,25%)", 255, 128, 64, 255 };
            yield return new object[] { "rgb(100%, 50%, 25%)", 255, 128, 64, 255 };
            yield return new object[] { "rgb( 100%,50%,25% )", 255, 128, 64, 255 };
            yield return new object[] { " rgb( 100%, 50%, 25% ) ", 255, 128, 64, 255 };
            yield return new object[] { "rgb 93.5%,50.3%,25.56%", 238, 128, 65, 255 };
            yield return new object[] { "rgb 100%, 50%, 25%", 255, 128, 64, 255 };
            yield return new object[] { "rgb 0.444%, 0.7856%, 0.4543%", 1, 2, 1, 255 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidRGBTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rbg(255,255,255)" };
            yield return new object[] { "rgb(255,255,255,23) " };
            yield return new object[] { "rgb(-255,255,255)" };
            yield return new object[] { "rgb(0.2,0.3,0.5)" };
            yield return new object[] { "rgb(0,0,0,0)" };
            yield return new object[] { "rgb( -0, 255, 255 )" };
            yield return new object[] { "rgb(255, 255,255, 0.1 )" };
            yield return new object[] { "rgba(255, 255,255, 0.1 )" };
            yield return new object[] { "rgb(255, 255,255, 30% )" };
            yield return new object[] { " rgb (255, 255,255)" };
            yield return new object[] { "rgb(255 255,255)" };
            yield return new object[] { "rgb(100%,255,255)" };
            yield return new object[] { "rgb(100%,101%,100%)" };
            yield return new object[] { "rgb(100,100,256)" };
            yield return new object[] { "rgb 100 100 256" };
            yield return new object[] { "rgb 100% 100% 255%" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region RGBA

    public class ValidRGBATestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rgba(255,255,255,0.5)" };
            yield return new object[] { " rgba(255,255,255,1) " };
            yield return new object[] { " rgba(255,255,255,0)" };
            yield return new object[] { " rgba(128,0,23,0.2)" };
            yield return new object[] { "rgba(0,0,0,1)" };
            yield return new object[] { "rgba( 255, 255, 255, 0.5 )" };
            yield return new object[] { "rgba(255, 255,255,.3 )" };
            yield return new object[] { "rgba(255, 255, 255, 0.6)" };
            yield return new object[] { "rgba( 255, 255, 255, 0.8 )" };
            yield return new object[] { "rgba(255,255,255,1)" };
            yield return new object[] { "rgba(2,42,14,0.1)" };
            yield return new object[] { "rgba(100%, 100%, 100%, 0.6)" };
            yield return new object[] { "rgba( 100%, 100%, 100%, 0.8 )" };
            yield return new object[] { "rgba(100%,100%,100%,1)" };
            yield return new object[] { "rgba(1.53%,35.55%,5.44%,.1)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidRGBAWithRGBAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rgba(255,255,255,0.5)", 255, 255, 255, 128 };
            yield return new object[] { " rgba(255,255,255,1) ", 255, 255, 255, 255 };
            yield return new object[] { " rgba(255,255,255,0)", 255, 255, 255, 0 };
            yield return new object[] { " rgba(128,0,23,0.2)", 128, 0, 23, 51 };
            yield return new object[] { "rgba(0,0,0,1)", 0, 0, 0, 255 };
            yield return new object[] { "rgba( 255, 255, 255,.3 )", 255, 255, 255, 77 };
            yield return new object[] { "rgba(255, 255,255, 0.6 )", 255, 255, 255, 153 };
            yield return new object[] { "rgba(255, 255, 255, 0.8)", 255, 255, 255, 204 };
            yield return new object[] { "rgba( 255, 255, 255, 1 )", 255, 255, 255, 255 };
            yield return new object[] { "rgba(255,255,255,1)", 255, 255, 255, 255 };
            yield return new object[] { "rgba(2,42,14,0.1)", 2, 42, 14, 26 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidRGBATestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "rbga(255,255,255,2)" };
            yield return new object[] { "rgba(255,255,255,1.1) " };
            yield return new object[] { "rgba(-255,255,255,-0.1)" };
            yield return new object[] { "rgba(0.2,0.3,0.5,-.1)" };
            yield return new object[] { "rgb(0,0,0,0)" };
            yield return new object[] { "rgb(0,255,255)" };
            yield return new object[] { "rgba(255, 255,255, 100 )" };
            yield return new object[] { "rgba(255, 255,255, -1 )" };
            yield return new object[] { "rgb(255, 255,255, 30% )" };
            yield return new object[] { "rgba(255, 255,255, 102% )" };
            yield return new object[] { "rgba(255, 255,255, -1% )" };
            yield return new object[] { "rgba(255, 255,255,  )" };
            yield return new object[] { "rgba(255, 255,255)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region HSL

    public class ValidHSLTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsl(0,100,100)" };
            yield return new object[] { " hsl(359.99,100%,50%) " };
            yield return new object[] { " hsl(100,50,50)" };
            yield return new object[] { " hsl(128,0,23%)" };
            yield return new object[] { "hsl(180deg,0%,0)" };
            yield return new object[] { "hsl( 180, 100%, 100% )" };
            yield return new object[] { "hsl(90, 100,100 )" };
            yield return new object[] { "hsl(0, 0%, 0%)" };
            yield return new object[] { "hsl 180 100 50" };
            yield return new object[] { "hsl 180deg 100% 50%" };
            yield return new object[] { "hsl(180 100 50)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidHSLWithRGBAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsl(0,100,100)", 255, 255, 255, 255 };
            yield return new object[] { " hsl(0,100%,50%) ", 255, 0, 0, 255 };
            yield return new object[] { " hsl(100,0,0)", 0, 0, 0, 255 };
            yield return new object[] { " hsl(128,0,23%)", 59, 59, 59, 255 };
            yield return new object[] { "hsl(180deg,66.6666%,30.8%)", 26, 131, 131, 255 };
            yield return new object[] { "hsl( 180, 100%, 100% )", 255, 255, 255, 255 };
            yield return new object[] { "hsl(90, 100,50 )", 128, 255, 0, 255 };
            yield return new object[] { "hsl(0, 50%, 20%)", 77, 25, 25, 255 };
            yield return new object[] { "hsl 180 100 50", 0, 255, 255, 255 };
            yield return new object[] { "hsl 180deg 100% 50%", 0, 255, 255, 255 };
            yield return new object[] { "hsl(180 100 50)", 0, 255, 255, 255 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidHSLTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsl(-180,100,100)" };
            yield return new object[] { "hsl(180,101,100)" };
            yield return new object[] { "hsl(180,100,101)" };
            yield return new object[] { "hsl(361,100,101)" };
            yield return new object[] { "hsl(180,100,100,0.5)" };
            yield return new object[] { "hsl(180,100,100,50%)" };
            yield return new object[] { "hsl(-180,100,100)" };
            yield return new object[] { "hsl(-180,100,100)" };
            yield return new object[] { "hsl(190 50 50 20)" };
            yield return new object[] { "hsl 190 50 50 20" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region HSLA

    public class ValidHSLATestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsla(0,100,100,0.5)" };
            yield return new object[] { " hsla(359.99,100%,50%,.2) " };
            yield return new object[] { " hsla(170,50,50,50)" };
            yield return new object[] { " hsla(128,0,23%,60%)" };
            yield return new object[] { "hsla(180deg,0%,0, .6)" };
            yield return new object[] { "hsla( 180, 100%, 100%, 0.6 )" };
            yield return new object[] { "hsla(90, 100,100,.7 )" };
            yield return new object[] { "hsla(0, 0%, 0%, 0%)" };
            yield return new object[] { "hsla 180 100 50 10" };
            yield return new object[] { "hsla 180 100 50 10%" };
            yield return new object[] { "hsla 180 100 50 10.67" };
            yield return new object[] { "hsla 180 100 50 10.65%" };
            yield return new object[] { "hsla 180 100 50 / 10%" };
            yield return new object[] { "hsla 180 100 50 / 0.1" };
            yield return new object[] { "hsla 180 100 50 / 0.4%" };
            yield return new object[] { "hsla 180deg 100% 50% .6" };
            yield return new object[] { "hsla(180 100 50 50%)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidHSLAWithRBGAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsla(0,100,100,0.5)", 255, 255, 255, 128 };
            yield return new object[] { " hsla(359.99,100%,50%,.2) ", 255, 0, 0, 51 };
            yield return new object[] { " hsla(100,0,0,0.7)", 0, 0, 0, 179 };
            yield return new object[] { " hsla(128,0,23%,1)", 59, 59, 59, 255 };
            yield return new object[] { "hsla(180deg,50%,0,0.6)", 0, 0, 0, 153 };
            yield return new object[] { "hsla( 180, 100%, 100%, 0.2 )", 255, 255, 255, 51 };
            yield return new object[] { "hsla(90, 100,50, 0.5 )", 128, 255, 0, 128 };
            yield return new object[] { "hsla(0, 50%, 20%, 0.5)", 77, 25, 25, 128 };
            yield return new object[] { "hsla 180 100 50 0.5", 0, 255, 255, 128 };
            yield return new object[] { "hsla 180deg 100% 50% 0.6", 0, 255, 255, 153 };
            yield return new object[] { "hsla(180 100 50 .7)", 0, 255, 255, 179 };
            yield return new object[] { "hsla 190 50 50 20", 64, 170, 191, 51 };
            yield return new object[] { "hsla 190 50 50 20.4%", 64, 170, 191, 52 };
            yield return new object[] { "hsla(190 50 50 20.4%)", 64, 170, 191, 52 };
            yield return new object[] { "hsla(190 50 50 20)", 64, 170, 191, 51 };
            yield return new object[] { "hsla(190, 50, 50, 20.4%)", 64, 170, 191, 52 };
            yield return new object[] { "hsla(190, 50, 50, 20)", 64, 170, 191, 51 };
            yield return new object[] { "hsla 180 100 50 10", 0, 255, 255, 26 };
            yield return new object[] { "hsla 180 100 50 10%", 0, 255, 255, 26 };
            yield return new object[] { "hsla 180 100 50 10.67", 0, 255, 255, 27 };
            yield return new object[] { "hsla 180 100 50 10.65%", 0, 255, 255, 27 };
            yield return new object[] { "hsla 180 100 50 / 10%", 0, 255, 255, 26 };
            yield return new object[] { "hsla 180 100 50 / 0.1", 0, 255, 255, 26 };
            yield return new object[] { "hsla 180 100 50 / 0.4%", 0, 255, 255, 1 };
            yield return new object[] { "hsla 180deg 100% 50% .6", 0, 255, 255, 153 };
            yield return new object[] { "hsla(180 100 50 50%)", 0, 255, 255, 128 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidHSLATestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsla(-180,100,100,1)" };
            yield return new object[] { "hsla(180,101,100,0)" };
            yield return new object[] { "hsla(180,100,101,1)" };
            yield return new object[] { "hsla(361,100,101,50)" };
            yield return new object[] { "hsla(180,100,100,-20)" };
            yield return new object[] { "hsla(180,100,100)" };
            yield return new object[] { "hsla(-180,100,100)" };
            yield return new object[] { "hsla(-0,100,100)" };
            yield return new object[] { "hsla(-0,100,-.4)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion

    #region HSV

    public class ValidHSVTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsv(0,100,100)" };
            yield return new object[] { " hsv(359.99,100%,50%) " };
            yield return new object[] { " hsv(100,50,50)" };
            yield return new object[] { " hsv(128,0,23%)" };
            yield return new object[] { "hsv(180deg,0%,0)" };
            yield return new object[] { "hsv( 180, 100%, 100% )" };
            yield return new object[] { "hsv(90, 100,100 )" };
            yield return new object[] { "hsv(0, 0%, 0%)" };
            yield return new object[] { "hsv 180 100 50" };
            yield return new object[] { "hsv 180deg 100% 50%" };
            yield return new object[] { "hsv(180 100 50)" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidHSVWithRGBAValueTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsv(0,100,100)", 255, 0, 0, 255 };
            yield return new object[] { " hsv(0,100%,50%) ", 128, 0, 0, 255 };
            yield return new object[] { " hsv(100,0,0)", 0, 0, 0, 255 };
            yield return new object[] { " hsv(128,0,23%)", 59, 59, 59, 255 };
            yield return new object[] { "hsv(180deg,50%,0)", 0, 0, 0, 255 };
            yield return new object[] { "hsv( 180, 100%, 100% )", 0, 255, 255, 255 };
            yield return new object[] { "hsv(90, 100,50 )", 64, 128, 0, 255 };
            yield return new object[] { "hsv(0, 50%, 20%)", 51, 26, 26, 255 };
            yield return new object[] { "hsv 180 100 50", 0, 128, 128, 255 };
            yield return new object[] { "hsv 180deg 100% 50%", 0, 128, 128, 255 };
            yield return new object[] { "hsv(180 100 50)", 0, 128, 128, 255 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidHSVTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "hsv(-180,100,100)" };
            yield return new object[] { "hsv(180,101,100)" };
            yield return new object[] { "hsv(180,100,101)" };
            yield return new object[] { "hsv(361,100,101)" };
            yield return new object[] { "hsv(180,100,100,0.5)" };
            yield return new object[] { "hsv(180,100,100,50%)" };
            yield return new object[] { "hsv(-180,100,100)" };
            yield return new object[] { "hsv(-180,100,100)" };
            yield return new object[] { "hsv(190 50 50 20)" };
            yield return new object[] { "hsv 190 50 50 20" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    #endregion
}

