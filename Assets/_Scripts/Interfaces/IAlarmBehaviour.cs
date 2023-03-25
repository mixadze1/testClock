using Assets._Scripts.Application.View;
using System;
using UnityEngine;

namespace Assets._Scripts.Interfaces
{
    public interface IAlarmBehaviour
    {
        Transform GetParentTransform();
        void SetTime(Transform clockView);

        int GetTime();
        void Initialize(DateTime dateTime, AlarmView alarmView);
    }
}