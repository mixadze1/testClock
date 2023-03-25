using System;

public interface IAlarmHandler
{
    void EnableAlarmWithArrow();
    void EnableAlarmWithInput();
    void DisableAlarm();

    void RemainingAlarm(DateTime time);
}