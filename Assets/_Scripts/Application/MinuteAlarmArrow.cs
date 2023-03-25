using System;
using UnityEngine;

public class MinuteAlarmArrow : AlarmArrow, IAlarmBehaviour
{
    public int GetTime() => _time;

    public void Initialize(DateTime dateTime, AlarmView clockView)
    {
        float eulerMinutes = 6;
        clockView.Minute.GetParentTransform().rotation = Quaternion.Euler(0, 0, -dateTime.Minute * eulerMinutes);
        Debug.Log("TimeMinute : " + dateTime.Minute + " Rotation : " + clockView.Minute.GetParentTransform().rotation.eulerAngles);
        SetTime(clockView.Minute.GetParentTransform());
    }

    public void SetTime(Transform clockView)
    {
        _time = (int)((clockView.rotation.eulerAngles.z - 360) / -6);
        if (_time == 60)
            _time = 0;
    }
}
