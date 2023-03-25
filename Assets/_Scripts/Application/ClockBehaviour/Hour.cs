using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets._Scripts.Application.ClockBehaviour
{
    public class Hour : IClockBehaviour
    {
        public void UpdateTime(DateTime time, ClockView clockView)
        {
            float eulerHour = 30;
            clockView.HourArrow.rotation = Quaternion.Euler(0, 0, -time.Hour * eulerHour);
        }
    }
}