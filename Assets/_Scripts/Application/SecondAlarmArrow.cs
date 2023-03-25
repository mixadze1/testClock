using System;
using UnityEngine;

public class SecondAlarmArrow : AlarmArrow, IAlarmBehaviour
{
    public int GetTime() => _time;

    public void Initialize(DateTime dateTime, AlarmView clockView)
    {
        float eulerSecond = 6;
        clockView.Second.GetParentTransform().rotation = Quaternion.Euler(0, 0, -dateTime.Second * eulerSecond);
        SetTime(clockView.Second.GetParentTransform());
    }

    public void SetTime(Transform clockView)
    {
        _time = (int)((clockView.rotation.eulerAngles.z - 360) / - 6);
        if(_time == 60)
            _time = 0;
        Debug.Log(_time + clockView.rotation.z);
    }
}