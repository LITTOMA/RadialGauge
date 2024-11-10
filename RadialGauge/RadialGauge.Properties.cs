
using System.Runtime.CompilerServices;

namespace RadialGauge;


public partial class RadialGauge
{
    // Bindable Properties Definitions
    public static readonly BindableProperty StartAngleProperty =
        BindableProperty.Create(
            nameof(StartAngle),
            typeof(float),
            typeof(RadialGauge),
            135f,
            propertyChanged: OnInvalidate);

    public float StartAngle
    {
        get => (float)GetValue(StartAngleProperty);
        set => SetValue(StartAngleProperty, value);
    }

    public static readonly BindableProperty SweepAngleProperty =
        BindableProperty.Create(
            nameof(SweepAngle),
            typeof(float),
            typeof(RadialGauge),
            270f,
            propertyChanged: OnInvalidate);

    public float SweepAngle
    {
        get => (float)GetValue(SweepAngleProperty);
        set => SetValue(SweepAngleProperty, value);
    }

    public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create(
            nameof(MinValue),
            typeof(float),
            typeof(RadialGauge),
            0f,
            propertyChanged: OnMinValueChanged);

    public float MinValue
    {
        get => (float)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(
            nameof(MaxValue),
            typeof(float),
            typeof(RadialGauge),
            100f,
            propertyChanged: OnMaxValueChanged);

    public float MaxValue
    {
        get => (float)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(
            nameof(Value),
            typeof(float),
            typeof(RadialGauge),
            0f,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: OnValueChanged,
            coerceValue: CoerceValue);

    public float Value
    {
        get => (float)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty TickIntervalProperty =
        BindableProperty.Create(
            nameof(TickInterval),
            typeof(float),
            typeof(RadialGauge),
            10f,
            propertyChanged: OnInvalidate);

    public float TickInterval
    {
        get => (float)GetValue(TickIntervalProperty);
        set => SetValue(TickIntervalProperty, value);
    }

    public static readonly BindableProperty TickLengthProperty =
        BindableProperty.Create(
            nameof(TickLength),
            typeof(float),
            typeof(RadialGauge),
            10f,
            propertyChanged: OnInvalidate);

    public float TickLength
    {
        get => (float)GetValue(TickLengthProperty);
        set => SetValue(TickLengthProperty, value);
    }

    public static readonly BindableProperty TickThicknessProperty =
        BindableProperty.Create(
            nameof(TickThickness),
            typeof(float),
            typeof(RadialGauge),
            2f,
            propertyChanged: OnInvalidate);

    public float TickThickness
    {
        get => (float)GetValue(TickThicknessProperty);
        set => SetValue(TickThicknessProperty, value);
    }

    public static readonly BindableProperty GaugeArcThicknessProperty =
        BindableProperty.Create(
            nameof(GaugeArcThickness),
            typeof(float),
            typeof(RadialGauge),
            4f,
            propertyChanged: OnInvalidate);

    public float GaugeArcThickness
    {
        get => (float)GetValue(GaugeArcThicknessProperty);
        set => SetValue(GaugeArcThicknessProperty, value);
    }

    public static readonly BindableProperty NeedleThicknessProperty =
        BindableProperty.Create(
            nameof(NeedleThickness),
            typeof(float),
            typeof(RadialGauge),
            2f,
            propertyChanged: OnInvalidate);

    public float NeedleThickness
    {
        get => (float)GetValue(NeedleThicknessProperty);
        set => SetValue(NeedleThicknessProperty, value);
    }

    public static readonly BindableProperty NeedleLengthProperty =
        BindableProperty.Create(
            nameof(NeedleLength),
            typeof(float),
            typeof(RadialGauge),
            0.8f,
            propertyChanged: OnInvalidate);

    public float NeedleLength
    {
        get => (float)GetValue(NeedleLengthProperty);
        set => SetValue(NeedleLengthProperty, value);
    }

    public static readonly BindableProperty GaugeBackgroundColorProperty =
        BindableProperty.Create(
            nameof(GaugeBackgroundColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Gray,
            propertyChanged: OnInvalidate);

    public Color GaugeBackgroundColor
    {
        get => (Color)GetValue(GaugeBackgroundColorProperty);
        set => SetValue(GaugeBackgroundColorProperty, value);
    }

    public static readonly BindableProperty GaugeFillColorProperty =
        BindableProperty.Create(
            nameof(GaugeFillColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Blue,
            propertyChanged: OnInvalidate);

    public Color GaugeFillColor
    {
        get => (Color)GetValue(GaugeFillColorProperty);
        set => SetValue(GaugeFillColorProperty, value);
    }

    public static readonly BindableProperty AlertValueProperty =
        BindableProperty.Create(
            nameof(AlertValue),
            typeof(float),
            typeof(RadialGauge),
            80f,
            propertyChanged: OnInvalidate);

    public float AlertValue
    {
        get => (float)GetValue(AlertValueProperty);
        set => SetValue(AlertValueProperty, value);
    }

    public static readonly BindableProperty AlertFillColorProperty =
        BindableProperty.Create(
            nameof(AlertFillColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Red,
            propertyChanged: OnInvalidate);

    public Color AlertFillColor
    {
        get => (Color)GetValue(AlertFillColorProperty);
        set => SetValue(AlertFillColorProperty, value);
    }

    public static readonly BindableProperty ShowAlertPointProperty = 
        BindableProperty.Create(
            nameof(ShowAlertPoint),
            typeof(bool),
            typeof(RadialGauge),
            false,
            propertyChanged: OnInvalidate);

    public bool ShowAlertPoint
    {
        get => (bool)GetValue(ShowAlertPointProperty);
        set => SetValue(ShowAlertPointProperty, value);
    }

    public static readonly BindableProperty LabelFontSizeProperty =
        BindableProperty.Create(
            nameof(LabelFontSize),
            typeof(float),
            typeof(RadialGauge),
            12f,
            propertyChanged: OnInvalidate);

    public float LabelFontSize
    {
        get => (float)GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }

    public static readonly BindableProperty LabelFontColorProperty =
        BindableProperty.Create(
            nameof(LabelFontColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Black,
            propertyChanged: OnInvalidate);

    public Color LabelFontColor
    {
        get => (Color)GetValue(LabelFontColorProperty);
        set => SetValue(LabelFontColorProperty, value);
    }

    public static readonly BindableProperty NeedleColorProperty =
        BindableProperty.Create(
            nameof(NeedleColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Black,
            propertyChanged: OnInvalidate);

    public Color NeedleColor
    {
        get => (Color)GetValue(NeedleColorProperty);
        set => SetValue(NeedleColorProperty, value);
    }

    public static readonly BindableProperty TickColorProperty =
        BindableProperty.Create(
            nameof(TickColor),
            typeof(Color),
            typeof(RadialGauge),
            Colors.Black,
            propertyChanged: OnInvalidate);

    public Color TickColor
    {
        get => (Color)GetValue(TickColorProperty);
        set => SetValue(TickColorProperty, value);
    }

    public static readonly BindableProperty ValueLabelFormatProperty =
        BindableProperty.Create(
            nameof(ValueLabelFormat),
            typeof(string),
            typeof(RadialGauge),
            "F2",
            propertyChanged: OnInvalidate);

    public string ValueLabelFormat
    {
        get => (string)GetValue(ValueLabelFormatProperty);
        set => SetValue(ValueLabelFormatProperty, value);
    }

    public static readonly BindableProperty UnitProperty =
        BindableProperty.Create(
            nameof(Unit),
            typeof(string),
            typeof(RadialGauge),
            "Unit",
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is RadialGauge radialGauge)
                {
                    radialGauge.Invalidate();
                    radialGauge.InvalidateMeasure();
                }
            });

    public string Unit
    {
        get => (string)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }



    // Helper Methods for Coercion and Property Changes
    private static void OnInvalidate(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is RadialGauge radialGauge)
        {
            radialGauge.Invalidate();
        }
    }

    private static void OnMinValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (RadialGauge)bindable;

        // Only refresh the UI if MinValue is less than or equal to MaxValue
        if (control.MinValue <= control.MaxValue)
        {
            control.CoerceValueProperty();
            control.Invalidate();
        }
    }

    private static void OnMaxValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (RadialGauge)bindable;

        // Only refresh the UI if MaxValue is greater than or equal to MinValue
        if (control.MaxValue >= control.MinValue)
        {
            control.CoerceValueProperty();
            control.Invalidate();
        }
    }

    private static object CoerceValue(BindableObject bindable, object value)
    {
        var control = (RadialGauge)bindable;

        // Only clamp the value if MinValue and MaxValue are in a valid state
        if (control.MinValue <= control.MaxValue)
        {
            return Math.Clamp((float)value, control.MinValue, control.MaxValue);
        }

        // If MinValue and MaxValue are not in a valid state, return the value as is
        return value;
    }

    private void CoerceValueProperty()
    {
        CoerceValue(this, Value);
    }

    private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (RadialGauge)bindable;

        // Only animate if MinValue and MaxValue are in a valid state
        if (control.MinValue <= control.MaxValue && newValue is float v)
        {
            control.AnimateTo(v);
        }
    }

}
