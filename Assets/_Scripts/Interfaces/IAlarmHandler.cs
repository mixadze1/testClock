using System;

namespace Assets._Scripts.Interfaces
{
    public interface IAlarmHandler
    {
        void EnableAlarmWithArrow();
        void EnableAlarmWithInput();
        void DisableAlarm();

        void RemainingAlarm(DateTime time);
    }
}