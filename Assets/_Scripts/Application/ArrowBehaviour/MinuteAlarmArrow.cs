using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public class MinuteAlarmArrow : AlarmArrow, IAlarmBehaviour
    {
        private float _maxTime = 60;
        public int GetTime() => _time;

        public void Initialize(DateTime dateTime, AlarmView clockView)
        {
            float eulerMinutes = 6;
            clockView.Minute.GetParentTransform().rotation = Quaternion.Euler(0, 0, -dateTime.Minute * eulerMinutes);
            SetTime(clockView.Minute.GetParentTransform());
        }

        public void SetTime(Transform clockView)
        {
            _time = (int)((clockView.rotation.eulerAngles.z - 360) / -6);
            if (_time == _maxTime)
                _time = 0;
        }
    }
}