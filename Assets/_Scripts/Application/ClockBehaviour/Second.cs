using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets._Scripts.Application.ClockBehaviour
{
    public class Second : IClockBehaviour
    {
        public void UpdateTime(DateTime time, ClockView clockView)
        {
            float eulerSecond = 6;
            clockView.SecondArrow.rotation = Quaternion.Euler(0, 0, -time.Second * eulerSecond);
        }
    }
}