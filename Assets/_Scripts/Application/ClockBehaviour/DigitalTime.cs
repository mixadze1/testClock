using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;

namespace Assets._Scripts.Application.ClockBehaviour
{
    public class DigitalTime : IClockBehaviour
    {
        public void UpdateTime(DateTime time, ClockView cloclView)
        {
            cloclView.TimeDigital.text = time.ToString("HH:mm:ss");
        }
    }
}