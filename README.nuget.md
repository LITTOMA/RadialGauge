#### RadialGauge Control

RadialGauge is a circular gauge control designed for .NET MAUI, drawn using Microsoft.Maui.Graphics, offering you a cross-platform and pixel-perfect control without relying on any third-party libraries like SkiaSharp.

##### Features:

- Customize start and end angles
- Set maximum and minimum values
- Define tick intervals
- Customize needle length and width
- Set gauge background color and fill color
- Define alert value and alert fill color
- Customize tick label font size and color
- Set needle color
- Dynamically set current needle position (value)

##### Usage:

1. Install the RadialGauge package from NuGet.
2. Create a RadialGauge instance in XAML or code, and set the desired properties.
3. Bind or set the Value property to dynamically update the needle position.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    ...
    xmlns:rg="clr-namespace:RadialGauge;assembly=RadialGauge">

<!-- ... -->

<rg:RadialGauge
    MinValue="0"
    MaxValue="100"
    Value="50"
    StartAngle="135"
    SweepAngle="270"
    TickInterval="10"
    GaugeArcColor="Gray"
    GaugeFillColor="Green"
    NeedleColor="Red" />

<!-- ... -->

</ContentPage>
```

##### Customizable Properties:

- `MinValue`: Minimum value
- `MaxValue`: Maximum value
- `Value`: Current value
- `StartAngle`: Start angle
- `SweepAngle`: Sweep angle
- `TickInterval`: Tick interval
- `GaugeArcColor`: Gauge background color
- `GaugeFillColor`: Gauge fill color
- `NeedleColor`: Needle color
- `AlertValue`: Alert value
- `AlertFillColor`: Fill color when value exceeds alert value
- `LabelFontSize`: Tick label font size
- `NeedleLength`: Needle length
- `NeedleThickness`: Needle thickness
- `TickLength`: Tick length
- `TickThickness`: Tick thickness
- `GaugeArcThickness`: Gauge background arc thickness


---

## License

MIT License

---

## Author

- [LITTOMA](https://github.com/LITTOMA)