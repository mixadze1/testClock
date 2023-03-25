using System;
using TMPro;
using UnityEngine;

public class Hour : IClockBehaviour
{
    public void UpdateTime(DateTime time, ClockView clockView)
    {
        float eulerHour = 30;
        clockView.HourArrow.rotation = Quaternion.Euler(0, 0, -time.Hour * eulerHour);
    }
}

public class Minute : IClockBehaviour
{
    public void UpdateTime(DateTime time, ClockView clockView)
    {
        float eulerMinutes = 6;
        clockView.MinuteArrow.rotation = Quaternion.Euler(0, 0, -time.Minute * eulerMinutes);
    }
}

public class Second : IClockBehaviour
{
    public void UpdateTime(DateTime time, ClockView clockView)
    {
        float eulerSecond = 6;
        clockView.SecondArrow.rotation = Quaternion.Euler(0, 0, -time.Second * eulerSecond);
    }
}

public class DigitalTime : IClockBehaviour
{
    public void UpdateTime(DateTime time, ClockView cloclView)
    {
        //Debug.Log(time.ToString("HH:mm:ss"));
        cloclView.TimeDigital.text = time.ToString("HH:mm:ss");
    }
}


