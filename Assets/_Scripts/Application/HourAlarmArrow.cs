using System;
using UnityEngine;

public class HourAlarmArrow : AlarmArrow, IAlarmBehaviour
{
    public int GetTime() => _time;

    public void Initialize(DateTime dateTime, AlarmView clockView)
    {
        float eulerHour = 15;
        clockView.Hour.GetParentTransform().rotation = Quaternion.Euler(0, 0, -dateTime.Hour * eulerHour);
        Debug.Log("TimeHOUr : " + dateTime.Hour + " Rotation : " + clockView.Hour.GetParentTransform().rotation.eulerAngles);
        SetTime(clockView.Hour.GetParentTransform());
    }

    public void SetTime(Transform clockView)
    {
        _time = (int)((clockView.rotation.eulerAngles.z- 360) /- 15f);
        Debug.Log((clockView.rotation.eulerAngles.z - 360) / -15f);
        Debug.Log(_time);
        if(_time == 24)
            _time = 0;
        Debug.Log(_time + " " + clockView.rotation.z);
    }
}
