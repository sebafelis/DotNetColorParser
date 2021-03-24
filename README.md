# DotNetColorParser

 ![NuGet Package](https://img.shields.io/nuget/v/DotNetColorParser)

.Net Standard library parsing color strings and converting them to .Net Color object. 
Library support almost all color notations used in CSS3 and supported color notations are extendable with custom.


## Usage

### Static methods

#### Any color notation

You can use static method witch converts string with any correct color notation supported by default. e.g:

```c#
string stringWithColor = "rgba(255,0,128,0.5)";

var color = ColorParser.Parse(stringWithColor);
```

In that case method try parse string using all notations added to `ColorParser.DefaultProvider` collection. This object by default contains all standard color notations.

#### Specify color notation only

If you wont to parser only one specify notation then you can write:

```c#
string stringWithColor = "#ff008080";

var color = ColorParser.Parse<HexRGBANotation>(stringWithColor);
```

In that case if you pass string like `"rgba(255,0,128,0.5)"` method throw the `UnkownColorNotationException`.

#### Customizing and extending supported color notations

You can add custom color notation support by adding to `ColorParser.DefaultProvider` custom object implementing `IColorNotation` interface.

To customize supported by default color notations you can set to `ColorParser.DefaultProvider` new ColorNotationProvider class instance.

```c#
ColorParser.DefaultProvider = new ColorNotationProvider() { HexRGBANotation, RGBANotation, RGBNotation };
```

### Class instance

You can dynamically create new instance of ColorParser class and configure supported notations by passing ColorNotationProvider object into constructor. 

```c#
var colorParser = new ColorParser(new ColorNotationProvider() { HexRGBANotation, RGBANotation, RGBNotation });

string stringWithColor = "#ff008080";

var color = colorParser.ParseColor(stringWithColor);
```

If you pass `null` in `ColorParser` instead `ColorNotationProvider` object then `ColorParser` use `ColorParser.DefaultProvider`.

### Inversion of Control (IoC)

You can use it also with IoC container:

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IColorNotationProvider>(()=> new ColorNotationProvider() { HexRGBANotation, RGBANotation, RGBNotation });
    services.AddSingleton<IColorParser, ColorParser>();
}
```

```c#
public class SomeClass
{
    readonly IColorParser colorParser;
    string stringWithColor = "#ff008080";

    public SomeClass(IColorParser colorParser) 
    {
        this.colorParser = colorParser;
    }

    public Color ReadColor()
    {
        return colorParser.ParseColor(_stringWithColor);
    }
}
```

## Supported color spaces:
* RGB
* RGBA
* HSL
* HSLA
* HSV

## Supported notations:

All this notations are default added to ColorNotationProvider.

| Class name | Description | Syntax | e.g. |
| :------------------- | :----------- | ------------------- | :---- |
| KnownColorNameNotation | Color names in English containing by [KnownColor](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.knowncolor?view=net-5.0&viewFallbackFrom=netstandard-2.0) enumerable object. It's contains all color names using by browsers. Colors are in RGB color space. Every color corresponding specify RBG value. | `colorname` | `silver`, `blue`, `black`, `green`, `yellow`, `darkblue` |
| HexRGBANotation | RGB or RGBA color expressed through hexadecimal value with # prefix (prefix not necessary to correct recognition). Color can be expressed as three, six or eight hexadecimal characters (0–9, A–F). | `#RRGGBB[AA]`<br />`#RGB[A]` | `#FFFFFF`, `#abc`, `#20ee33`, `#ff1250cc` |
| RGBNotation | [RGB color](https://developer.mozilla.org/en-US/docs/Web/CSS/color_value#rgb_colors)| **Syntax 1:** rgb(R, G, B)<br />**Syntax 2:** rgb R G B | `rgb(255,255,0)`, `rgb( 255, 255, 255 )` |
| RGBANotation | The same as RGBNotation but with additional alpha channel. | **Syntax 1:** rgba(R, G, B, A)<br />**Syntax 2:** rgba R G B A<br />**Syntax 3:** rgba R G B / A<br />**Syntax 4:** rgba(R G B / A) | `rgba(255,255,0,0.5)`, `rgba( 255, 255, 255, 100% )` |
| HSLNotation | [HSLA color space](https://en.wikipedia.org/wiki/HSL_and_HSV) | **Syntax 1:** `hsl(hue, spectrum, lightness)`<br />**Syntax 2:** `hsl hue, spectrum, lightness`<br />**Syntax 4:** `hsla(hue spectrum lightness)`<br /><br /> | `hsla(180,50%,50%,0.5)`, `hsla(180,50%,50%,30%)`, `hsla(180deg,50%,50%,30%)`, `hsla(4rad,50%,50%,30%)`, `hsla(4ang,50%,50%,30%)`,`hsla 180,50%,50%,0.5`, `hsla 180 50% 50% 0.5`, `hsla 180 50% 50% / 0.5`
| HSLANotation | The same as HSLNotation but with additional alpha channel. | **Syntax 1:** `hsla(hue, spectrum, lightness, alpha)`<br />**Syntax 2:** `hsla hue, spectrum, lightness / alpha`<br />**Syntax 3:** `hsla hue spectrum lightness alpha`<br />**Syntax 4:** `hsla(hue spectrum lightness alpha)` | `hsla(180,50%,50%,0.5)`, `hsla(180,50%,50%,30%)`, `hsla(180deg,50%,50%,30%)`, `hsla(4rad,50%,50%,30%)`, `hsla(4ang,50%,50%,30%)`,`hsla 180,50%,50%,0.5`, `hsla 180 50% 50% 0.5`, `hsla 180 50% 50% / 0.5`
| HSVNotation | [HSVA color space](https://en.wikipedia.org/wiki/HSL_and_HSV) | **Syntax 1:** `hsla(hue, spectrum, lightness, alpha)`<br />**Syntax 2:** `hsla hue, spectrum, lightness / alpha`<br />**Syntax 3:** `hsla hue spectrum lightness alpha`<br />**Syntax 4:** `hsla(hue spectrum lightness alpha)` | `hsla(180,50%,50%,0.5)`, `hsla(180,50%,50%,30%)`, `hsla(180deg,50%,50%,30%)`, `hsla(4rad,50%,50%,30%)`, `hsla(4ang,50%,50%,30%)`,`hsla 180,50%,50%,0.5`, `hsla 180 50% 50% 0.5`, `hsla 180 50% 50% / 0.5`

**R** (red), **G** (green), **B** (blue) - number between 0 and 255.

**A** - decimal number between 0 and 1 or percentage value between 0% and 100%

**hue** - value between 0 and 360 degrees [deg], value can be also specify in other angels units like radius [rad], gradus [grad], turns [turn].

**saturation**, **lightness**, **alpha** - percentage value between 0% and 100% or decimal number between 0 and 1.

