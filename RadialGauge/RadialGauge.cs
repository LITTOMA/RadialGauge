namespace RadialGauge;

public partial class RadialGauge : GraphicsView, IDrawable
{
    // IDrawable�ӿڵ�ʵ��
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // ��ȡ�ؼ������ĵ�
        float centerX = dirtyRect.Width / 2;
        float centerY = dirtyRect.Height / 2;

        // ����ָ��ĽǶ�
        float valuePercentage = (_animatedValue - MinValue) / (MaxValue - MinValue);
        float needleAngle = StartAngle + (SweepAngle * valuePercentage);

        // ������̵İ뾶
        float radius = Math.Min(centerX, centerY) - 10 - GaugeArcThickness;  // ��10Ϊ����һЩ�߾�

        // ���Ʊ��̱��������
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
        canvas.StrokeColor = GaugeFillColor;
        canvas.DrawArc(arcRect, gaugeStartAngle, gaugeFillStopAngle, true, false);

        // ����ָ����յ����꣬ʹ�� NeedleLength ���Ե�������
        double needleEndX = centerX + (radius * NeedleLength * Math.Cos(needleAngle * Math.PI / 180));
        double needleEndY = centerY + (radius * NeedleLength * Math.Sin(needleAngle * Math.PI / 180));

        // ����ָ��
        canvas.StrokeColor = NeedleColor;
        canvas.StrokeSize = NeedleThickness;
        canvas.DrawLine(centerX, centerY, (float)needleEndX, (float)needleEndY);

        // ����̶ȵ�����
        int tickCount = (int)((MaxValue - MinValue) / TickInterval) + 1;

        // ���ƿ̶�
        for (int i = 0; i < tickCount; i++)
        {
            float tickValue = MinValue + (i * TickInterval);
            float tickPercentage = (tickValue - MinValue) / (MaxValue - MinValue);
            float tickAngle = StartAngle + (SweepAngle * tickPercentage);

            // ����̶ȵ������յ�����
            float tickStartX = centerX + ((radius - TickLength - GaugeArcThickness) * MathF.Cos(tickAngle * MathF.PI / 180));
            float tickStartY = centerY + ((radius - TickLength - GaugeArcThickness) * MathF.Sin(tickAngle * MathF.PI / 180));
            float tickEndX = centerX + ((radius - GaugeArcThickness) * MathF.Cos(tickAngle * MathF.PI / 180));
            float tickEndY = centerY + ((radius - GaugeArcThickness) * MathF.Sin(tickAngle * MathF.PI / 180));

            // ���ƿ̶���
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawLine(tickStartX, tickStartY, tickEndX, tickEndY);
        }

        float labelY = centerY + (radius * MathF.Sin(StartAngle * MathF.PI / 180)) + LabelFontSize + GaugeArcThickness;
        canvas.FontSize = LabelFontSize;

        // ������Сֵ��ǩ
        float minLabelX = centerX + (radius * MathF.Cos(StartAngle * MathF.PI / 180));
        canvas.DrawString(MinValue.ToString(), minLabelX, labelY, HorizontalAlignment.Center);

        // �������ֵ��ǩ
        float maxLabelX = centerX + (radius * MathF.Cos((StartAngle + SweepAngle) * MathF.PI / 180));
        canvas.DrawString(MaxValue.ToString(), maxLabelX, labelY, HorizontalAlignment.Center);

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
            float step = (_targetValue - _animatedValue) * 0.1f;  // �򵥵����Բ�ֵ
            _animatedValue += step;
        }

        Invalidate();  // �����ػ�ؼ�
    }


    public RadialGauge()
    {
        Drawable = this;

        _animationTimer = new System.Timers.Timer(16);  // ���ö���֡��Ϊ60fps
        _animationTimer.Elapsed += OnAnimationTick;
    }

    private float _animatedValue;
    private float _targetValue;
    private System.Timers.Timer _animationTimer;
}
