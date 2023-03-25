using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public class HourAlarmArrow : AlarmArrow, IAlarmBehaviour
    {
        private float _maxTime = 24;
        public int GetTime() => _time;

        public void Initialize(DateTime dateTime, AlarmView clockView)
        {
            float eulerHour = 15;
            clockView.Hour.GetParentTransform().rotation = Quaternion.Euler(0, 0, -dateTime.Hour * eulerHour);
            SetTime(clockView.Hour.GetParentTransform());
        }

        public void SetTime(Transform clockView)
        {
            _time = (int)((clockView.rotation.eulerAngles.z - 360) / -15f);
            if (_time == _maxTime)
                _time = 0;
        }
    }
}