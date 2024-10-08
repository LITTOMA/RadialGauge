﻿namespace RadialGaugeTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Random random;

        public MainPage()
        {
            InitializeComponent();

            random = new Random(DateTime.Now.Millisecond);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            gauge.Value = random.NextSingle() * 100;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if(sender is RadialGauge.RadialGauge radialGauge)
            {
                //radialGauge.MinValue = radialGauge.MinValue == 0 ? 50 : 0;
                //radialGauge.MaxValue = radialGauge.MaxValue == 50 ? 100 : 150;
                radialGauge.Value = random.Next((int)radialGauge.MinValue, (int)radialGauge.MaxValue);
            }
        }
    }

}
