namespace RadialGauge;

public partial class RadialGauge : GraphicsView, IDrawable
{
    // IDrawable接口的实现
    // Implmentation of IDrawable interface
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // 获取控件的中心点
        // Get the center point of the control
        float centerX = dirtyRect.Width / 2;
        float centerY = dirtyRect.Height / 2;

        // 计算指针的角度
        // Calculate the angle of the needle
        float valuePercentage = (_animatedValue - MinValue) / (MaxValue - MinValue);
        float needleAngle = CalculateAngle(valuePercentage);

        // 计算表盘的半径
        // Calculate the radius of the gauge
        float radius = Math.Min(centerX, centerY) - 10 - GaugeArcThickness;  // 减10为了留一些边距 // Subtract 10 to leave some margin

        // 绘制表盘背景和填充
        // Draw the gauge background and fill
        var arcX = centerX - radius;
        var arcY = centerY - radius;
        var arcRect = new RectF(arcX, arcY, radius * 2, radius * 2);
        var gaugeStartAngle = ArcAngle(StartAngle);
        var gaugeBackgroundStopAngle = ArcAngle(StartAngle + SweepAngle);
        var gaugeFillStopAngle = ArcAngle(needleAngle);

        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeSize = GaugeArcThickness;
        canvas.StrokeColor = GaugeBackgroundColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeBackgroundStopAngle, true, false);
        canvas.StrokeColor = _animatedValue >= AlertValue ? AlertFillColor : GaugeFillColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeFillStopAngle, true, false);

        // 计算指针的终点坐标，使用 NeedleLength 属性调整长度
        // Calculate the end point of the needle, use the NeedleLength property to adjust the length
        var needleEnd = CalculatePoint(centerX, centerY, radius * NeedleLength, needleAngle);

        // 绘制指针
        // Draw the needle
        canvas.StrokeColor = NeedleColor;
        canvas.StrokeSize = NeedleThickness;
        canvas.DrawLine(centerX, centerY, (float)needleEnd.X, (float)needleEnd.Y);

        // 计算刻度的数量
        // Calculate the number of ticks
        int tickCount = (int)((MaxValue - MinValue) / TickInterval) + 1;

        // 绘制刻度
        // Draw the ticks
        for (int i = 0; i < tickCount; i++)
        {
            float tickValue = MinValue + (i * TickInterval);
            float tickPercentage = (tickValue - MinValue) / (MaxValue - MinValue);
            float tickAngle = CalculateAngle(tickPercentage);

            // 计算刻度的起点和终点坐标
            // Calculate the start and end points of the tick
            var tickStart = CalculatePoint(centerX, centerY, radius - TickLength - GaugeArcThickness, tickAngle);
            var tickEnd = CalculatePoint(centerX, centerY, radius - GaugeArcThickness, tickAngle);

            // 绘制刻度线
            // Draw the tick line
            canvas.StrokeColor = TickColor;
            canvas.StrokeSize = 2;
            canvas.DrawLine(tickStart.X, tickStart.Y, tickEnd.X, tickEnd.Y);
        }

        if (ShowAlertPoint)
        {
            // 在表盘内测绘制一个红色的圆圈，用于标记警告值
            // Draw a red circle inside the gauge to mark the alert value
            var alertAngle = CalculateAngle((AlertValue - MinValue) / (MaxValue - MinValue));
            var alertPoint = CalculatePoint(centerX, centerY, radius - TickLength - GaugeArcThickness - 10, alertAngle);
            canvas.FillColor = Colors.Red;
            canvas.FillCircle(alertPoint.X, alertPoint.Y, 4);
        }

        float labelY = centerY + (radius * MathF.Sin(StartAngle * MathF.PI / 180)) + LabelFontSize + GaugeArcThickness;
        canvas.FontSize = LabelFontSize;
        canvas.FontColor = LabelFontColor;

        // 绘制最小值标签
        // Draw the minimum value label
        float minLabelX = centerX + (radius * MathF.Cos(StartAngle * MathF.PI / 180));
#if IOS
        canvas.DrawString(
            MinValue.ToString(),
            minLabelX, labelY,
            100, 100,
            HorizontalAlignment.Left, VerticalAlignment.Top,
            TextFlow.OverflowBounds);
#else
        canvas.DrawString(MinValue.ToString(), minLabelX, labelY, HorizontalAlignment.Center);
#endif

        // 绘制最大值标签
        // Draw the maximum value label
        float maxLabelX = centerX + (radius * MathF.Cos((StartAngle + SweepAngle) * MathF.PI / 180));
#if IOS
        canvas.DrawString(
            MaxValue.ToString(),
            maxLabelX, labelY,
            100, 100,
            HorizontalAlignment.Left, VerticalAlignment.Top,
            TextFlow.OverflowBounds);
#else
        canvas.DrawString(MaxValue.ToString(), maxLabelX, labelY, HorizontalAlignment.Center);
#endif

        // 绘制当前值标签
        // Draw the current value label
        canvas.FontSize = LabelFontSize;
        float valueLabelX = centerX;
        float valueLabelY = centerY + LabelFontSize;
#if IOS
        canvas.DrawString(
            _animatedValue.ToString(ValueLabelFormat),
            valueLabelX, valueLabelY,
            100, 100,
            HorizontalAlignment.Left, VerticalAlignment.Top,
            TextFlow.OverflowBounds);
#else
        canvas.DrawString(_animatedValue.ToString(ValueLabelFormat), valueLabelX, valueLabelY, HorizontalAlignment.Center);
#endif

        // 绘制单位标签
        // Draw the units label
        float unitsLabelY = valueLabelY + LabelFontSize + 8;
#if IOS
        canvas.DrawString(
            Unit,
            valueLabelX, unitsLabelY,
            100, 100,
            HorizontalAlignment.Left, VerticalAlignment.Top,
            TextFlow.OverflowBounds);
#else
        canvas.DrawString(Unit, valueLabelX, unitsLabelY, HorizontalAlignment.Center);
#endif

    }

    private float CalculateAngle(float percentage)
    {
        return StartAngle + (SweepAngle * percentage);
    }

    private PointF CalculatePoint(float centerX, float centerY, float radius, float angle)
    {
        float x = centerX + (radius * MathF.Cos(angle * MathF.PI / 180));
        float y = centerY + (radius * MathF.Sin(angle * MathF.PI / 180));
        return new PointF(x, y);
    }

    private float ArcAngle(float angle)
    {
        float normalizedAngle = ((angle % 360) + 360) % 360;
        if (normalizedAngle < 180)
            return -normalizedAngle;
        else
            return 360 - normalizedAngle;
    }

    public void AnimateTo(float value)
    {
        _animatedValue = Math.Clamp(_animatedValue, MinValue, MaxValue);
        _targetValue = Math.Clamp(value, MinValue, MaxValue);
        _animationTimer.Start();
    }

    private void OnAnimationTick(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (Math.Abs(_animatedValue - _targetValue) < 0.1)
        {
            _animationTimer.Stop();
            _animatedValue = _targetValue;
        }
        else
        {
            float step = (_targetValue - _animatedValue) * 0.1f;  // 简单的线性插值 // Simple linear interpolation
            _animatedValue += step;
        }

        SafeInvalidate();  // 请求重绘控件 // Request a redraw of the control
    }

    private void SafeInvalidate()
    {
        this.Dispatcher.Dispatch(() => Invalidate());
    }

    public RadialGauge()
    {
        Drawable = this;

        _animationTimer = new System.Timers.Timer(16);  // 设置动画帧率为60fps // Set the animation frame rate to 60fps
        _animationTimer.Elapsed += OnAnimationTick;
    }

    private float _animatedValue;
    private float _targetValue;
    private System.Timers.Timer _animationTimer;
}
