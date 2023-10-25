
using System.Runtime.CompilerServices;

namespace RadialGauge;


public partial class RadialGauge
{
    public static readonly BindableProperty StartAngleProperty =
        BindableProperty.Create(nameof(StartAngle), typeof(float), typeof(RadialGauge), 135f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float StartAngle
    {
        get => (float)GetValue(StartAngleProperty);
        set => SetValue(StartAngleProperty, value);
    }

    public static readonly BindableProperty SweepAngleProperty =
        BindableProperty.Create(nameof(SweepAngle), typeof(float), typeof(RadialGauge), 270f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float SweepAngle
    {
        get => (float)GetValue(SweepAngleProperty);
        set => SetValue(SweepAngleProperty, value);
    }

    public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create(nameof(MinValue), typeof(float), typeof(RadialGauge), 0f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float MinValue
    {
        get => (float)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(RadialGauge), 100f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float MaxValue
    {
        get => (float)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(float), typeof(RadialGauge), 0f, propertyChanged: OnValueChanged);

    private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RadialGauge radialGauge && newValue is float v)
        {
            radialGauge.AnimateTo(v);
        }
    }

    public float Value
    {
        get => (float)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty TickIntervalProperty =
        BindableProperty.Create(nameof(TickInterval), typeof(float), typeof(RadialGauge), 10f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float TickInterval
    {
        get => (float)GetValue(TickIntervalProperty);
        set => SetValue(TickIntervalProperty, value);
    }

    public static readonly BindableProperty TickLengthProperty =
        BindableProperty.Create(nameof(TickLength), typeof(float), typeof(RadialGauge), 10f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });

    public float TickLength
    {
        get => (float)GetValue(TickLengthProperty);
        set => SetValue(TickLengthProperty, value);
    }

    public static readonly BindableProperty TickThicknessProperty =
        BindableProperty.Create(nameof(TickThickness), typeof(float), typeof(RadialGauge), 2f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });

    public float TickThickness
    {
        get => (float)GetValue(TickThicknessProperty);
        set => SetValue(TickThicknessProperty, value);
    }

    public static readonly BindableProperty GaugeArcThicknessProperty =
        BindableProperty.Create(nameof(GaugeArcThickness), typeof(float), typeof(RadialGauge), 4f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });

    public float GaugeArcThickness
    {
        get => (float)GetValue(GaugeArcThicknessProperty);
        set => SetValue(GaugeArcThicknessProperty, value);
    }

    public static readonly BindableProperty NeedleThicknessProperty =
        BindableProperty.Create(nameof(NeedleThickness), typeof(float), typeof(RadialGauge), 2f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float NeedleThickness
    {
        get => (float)GetValue(NeedleThicknessProperty);
        set => SetValue(NeedleThicknessProperty, value);
    }

    public static readonly BindableProperty NeedleLengthProperty =
        BindableProperty.Create(nameof(NeedleLength), typeof(float), typeof(RadialGauge), 0.8f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float NeedleLength
    {
        get => (float)GetValue(NeedleLengthProperty);
        set => SetValue(NeedleLengthProperty, value);
    }

    public static readonly BindableProperty GaugeBackgroundColorProperty =
        BindableProperty.Create(nameof(GaugeBackgroundColor), typeof(Color), typeof(RadialGauge), Colors.Gray, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public Color GaugeBackgroundColor
    {
        get => (Color)GetValue(GaugeBackgroundColorProperty);
        set => SetValue(GaugeBackgroundColorProperty, value);
    }

    public static readonly BindableProperty GaugeFillColorProperty =
        BindableProperty.Create(nameof(GaugeFillColor), typeof(Color), typeof(RadialGauge), Colors.Blue, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public Color GaugeFillColor
    {
        get => (Color)GetValue(GaugeFillColorProperty);
        set => SetValue(GaugeFillColorProperty, value);
    }

    public static readonly BindableProperty WarningValueProperty =
        BindableProperty.Create(nameof(WarningValue), typeof(float), typeof(RadialGauge), 80f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float WarningValue
    {
        get => (float)GetValue(WarningValueProperty);
        set => SetValue(WarningValueProperty, value);
    }

    public static readonly BindableProperty WarningFillColorProperty =
        BindableProperty.Create(nameof(WarningFillColor), typeof(Color), typeof(RadialGauge), Colors.Red, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public Color WarningFillColor
    {
        get => (Color)GetValue(WarningFillColorProperty);
        set => SetValue(WarningFillColorProperty, value);
    }

    public static readonly BindableProperty LabelFontSizeProperty =
        BindableProperty.Create(nameof(LabelFontSize), typeof(float), typeof(RadialGauge), 12f, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public float LabelFontSize
    {
        get => (float)GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }

    public static readonly BindableProperty LabelFontColorProperty =
        BindableProperty.Create(nameof(LabelFontColor), typeof(Color), typeof(RadialGauge), Colors.Black, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public Color LabelFontColor
    {
        get => (Color)GetValue(LabelFontColorProperty);
        set => SetValue(LabelFontColorProperty, value);
    }

    public static readonly BindableProperty NeedleColorProperty =
        BindableProperty.Create(nameof(NeedleColor), typeof(Color), typeof(RadialGauge), Colors.Black, propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public Color NeedleColor
    {
        get => (Color)GetValue(NeedleColorProperty);
        set => SetValue(NeedleColorProperty, value);
    }

    public static readonly BindableProperty IsInteractiveProperty =
        BindableProperty.Create(nameof(IsInteractive), typeof(bool), typeof(RadialGauge), false);

    public bool IsInteractive
    {
        get => (bool)GetValue(IsInteractiveProperty);
        set => SetValue(IsInteractiveProperty, value);
    }

    public static readonly BindableProperty ValueLableFormatProperty =
        BindableProperty.Create(nameof(ValueLableFormat), typeof(string), typeof(RadialGauge), "F2", propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); } });
    public string ValueLableFormat
    {
        get => (string)GetValue(ValueLableFormatProperty);
        set => SetValue(ValueLableFormatProperty, value);
    }

    public static readonly BindableProperty UnitProperty =
        BindableProperty.Create(nameof(Unit), typeof(string), typeof(RadialGauge), "Unit", propertyChanged: (bindable, oldValue, newValue) => { if (bindable is RadialGauge radialGauge) { radialGauge.Invalidate(); radialGauge.InvalidateMeasure(); } });
    public string Unit
    {
        get => (string)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }
}
