using System;
using UnityEngine;

public interface IAlarmBehaviour
{
   Transform GetParentTransform();
    void SetTime(Transform clockView);

    int GetTime();
    void Initialize(DateTime dateTime, AlarmView alarmView);
}
