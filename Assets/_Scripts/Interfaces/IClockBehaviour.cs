using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClockBehaviour 
{
    void UpdateTime(DateTime time, ClockView transform);
}
