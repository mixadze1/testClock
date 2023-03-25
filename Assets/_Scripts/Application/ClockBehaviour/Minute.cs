using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets._Scripts.Application.ClockBehaviour
{
    public class Minute : IClockBehaviour
    {
        public void UpdateTime(DateTime time, ClockView clockView)
        {
            float eulerMinutes = 6;
            clockView.MinuteArrow.rotation = Quaternion.Euler(0, 0, -time.Minute * eulerMinutes);
        }
    }
}