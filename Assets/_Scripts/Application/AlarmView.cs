using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlarmView : MonoBehaviour
{
    [Header("AlarmArrow")]
    public HourAlarmArrow Hour;
    public MinuteAlarmArrow Minute;
    public SecondAlarmArrow Second;

    [Header("AlarmInput")]
    public HourInput HourInput;
    public MinuteInput MinuteInput;
    public SecondInput SecondInput;

    public RectTransform ActivateAlarm;

    public RectTransform AlarmContainer;

    public TextMeshProUGUI TextAlarmView;

    private IAlarmHandler _alarmHandler;

    public void UpdateView(DateTime dateTime)
    {
        TextAlarmView.text = dateTime.ToString("HH:mm:ss");
    }

    public void Initialize(IAlarmHandler alarmHandler)
    {
        _alarmHandler = alarmHandler;
    }

    public void EnableAlarmWithArrow()
    {
        _alarmHandler.EnableAlarmWithArrow();
    }

    public void EnableAlarmWithInput()
    {
        _alarmHandler.EnableAlarmWithInput();
    }

    public void DisableAlarm()
    {
        _alarmHandler.DisableAlarm();
    }
}
