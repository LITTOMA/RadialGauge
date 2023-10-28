
# RadialGauge 控件

RadialGauge 是一个为 .NET MAUI 设计的环形度量仪表盘控件。它通过 Microsoft.Maui.Graphics 绘制，为你提供了一个跨平台且像素完美的控件，无需依赖任何第三方库（如 SkiaSharp）。

##### 特性:

- 自定义起始和结束角度
- 设置最大值和最小值
- 定义刻度间隔
- 自定义指针的长度和宽度
- 设置表盘背景颜色和填充颜色
- 定义告警值和告警填充颜色
- 自定义刻度标签的字体大小和颜色
- 设置指针颜色
- 动态设置当前指针位置（值）

##### 使用方法:

1. 从 NuGet 安装 RadialGauge 包。
2. 在 XAML 或代码中创建 RadialGauge 实例，并设置所需的属性。
3. 绑定或设置 Value 属性来动态更新指针的位置。

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

##### 可定制的属性:

- `MinValue`: 最小值
- `MaxValue`: 最大值
- `Value`: 当前值
- `StartAngle`: 起始角度
- `SweepAngle`: 扫过的角度
- `TickInterval`: 刻度间隔
- `GaugeArcColor`: 表盘背景颜色
- `GaugeFillColor`: 表盘填充颜色
- `NeedleColor`: 指针颜色
- `AlertValue`: 告警值
- `AlertFillColor`: 超过告警值时的填充颜色
- `LabelFontSize`: 刻度标签字体大小
- `NeedleLength`: 指针长度
- `NeedleThickness`: 指针粗细
- `TickLength`: 刻度长度
- `TickThickness`: 刻度粗细
- `GaugeArcThickness`: 表盘背景圆弧粗细

---

### English Version

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