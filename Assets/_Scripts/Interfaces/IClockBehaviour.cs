using Assets._Scripts.Application.View;
using System;

namespace Assets._Scripts.Interfaces
{
    public interface IClockBehaviour
    {
        void UpdateTime(DateTime time, ClockView transform);
    }
}