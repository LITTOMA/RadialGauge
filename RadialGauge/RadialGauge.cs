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
        float needleAngle = StartAngle + (SweepAngle * valuePercentage);

        // 计算表盘的半径
        // Calculate the radius of the gauge
        float radius = Math.Min(centerX, centerY) - 10 - GaugeArcThickness;  // 减10为了留一些边距 // Subtract 10 to leave some margin

        // 绘制表盘背景和填充
        // Draw the gauge background and fill
        var arcX = centerX - radius;
        var arcY = centerY - radius;
        var arcRect = new RectF(arcX, arcY, radius * 2, radius * 2);
        var gaugeStartAngle = NormalizeAngle(StartAngle);
        var gaugeBackgroundStopAngle = NormalizeAngle(StartAngle + SweepAngle);
        var gaugeFillStopAngle = NormalizeAngle(needleAngle);

        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeSize = GaugeArcThickness;
        canvas.StrokeColor = GaugeBackgroundColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeBackgroundStopAngle, true, false);
        canvas.StrokeColor = _animatedValue >= AlertValue ? AlertFillColor : GaugeFillColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeFillStopAngle, true, false);

        // 计算指针的终点坐标，使用 NeedleLength 属性调整长度
        // Calculate the end point of the needle, use the NeedleLength property to adjust the length
        double needleEndX = centerX + (radius * NeedleLength * Math.Cos(needleAngle * Math.PI / 180));
        double needleEndY = centerY + (radius * NeedleLength * Math.Sin(needleAngle * Math.PI / 180));

        // 绘制指针
        // Draw the needle
        canvas.StrokeColor = NeedleColor;
        canvas.StrokeSize = NeedleThickness;
        canvas.DrawLine(centerX, centerY, (float)needleEndX, (float)needleEndY);

        // 计算刻度的数量
        // Calculate the number of ticks
        int tickCount = (int)((MaxValue - MinValue) / TickInterval) + 1;

        // 绘制刻度
        // Draw the ticks
        for (int i = 0; i < tickCount; i++)
        {
            float tickValue = MinValue + (i * TickInterval);
            float tickPercentage = (tickValue - MinValue) / (MaxValue - MinValue);
            float tickAngle = StartAngle + (SweepAngle * tickPercentage);

            // 计算刻度的起点和终点坐标
            // Calculate the start and end points of the tick
            float tickStartX = centerX + ((radius - TickLength - GaugeArcThickness) * MathF.Cos(tickAngle * MathF.PI / 180));
            float tickStartY = centerY + ((radius - TickLength - GaugeArcThickness) * MathF.Sin(tickAngle * MathF.PI / 180));
            float tickEndX = centerX + ((radius - GaugeArcThickness) * MathF.Cos(tickAngle * MathF.PI / 180));
            float tickEndY = centerY + ((radius - GaugeArcThickness) * MathF.Sin(tickAngle * MathF.PI / 180));

            // 绘制刻度线
            // Draw the tick line
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawLine(tickStartX, tickStartY, tickEndX, tickEndY);
        }

        float labelY = centerY + (radius * MathF.Sin(StartAngle * MathF.PI / 180)) + LabelFontSize + GaugeArcThickness;
        canvas.FontSize = LabelFontSize;

        // 绘制最小值标签
        // Draw the minimum value label
        float minLabelX = centerX + (radius * MathF.Cos(StartAngle * MathF.PI / 180));
        canvas.DrawString(MinValue.ToString(), minLabelX, labelY, HorizontalAlignment.Center);

        // 绘制最大值标签
        // Draw the maximum value label
        float maxLabelX = centerX + (radius * MathF.Cos((StartAngle + SweepAngle) * MathF.PI / 180));
        canvas.DrawString(MaxValue.ToString(), maxLabelX, labelY, HorizontalAlignment.Center);

        // 绘制当前值标签
        // Draw the current value label
        canvas.FontSize = LabelFontSize;
        float valueLabelX = centerX;
        float valueLabelY = centerY + LabelFontSize;
        canvas.DrawString(_animatedValue.ToString(ValueLableFormat), valueLabelX, valueLabelY, HorizontalAlignment.Center);

        // 绘制单位标签
        // Draw the units label
        float unitsLabelY = valueLabelY + LabelFontSize + 8;
        canvas.DrawString(Unit, valueLabelX, unitsLabelY, HorizontalAlignment.Center);

    }

    private float NormalizeAngle(float angle)
    {
        float normalizedAngle = ((angle % 360) + 360) % 360;
        if (normalizedAngle < 180)
            return -normalizedAngle;
        else
            return 360 - normalizedAngle;
    }

    public void AnimateTo(float value)
    {
        _targetValue = value;
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

        Invalidate();  // 请求重绘控件 // Request a redraw of the control
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
