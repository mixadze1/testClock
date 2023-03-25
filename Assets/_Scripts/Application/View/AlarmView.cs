using Assets._Scripts.Application.ArrowBehaviour;
using Assets._Scripts.Application.InputFieldBehaviour;
using Assets._Scripts.Interfaces;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.Application.View
{
    public class AlarmView : MonoBehaviour
    {
        [Header("AlarmArrow")] // if more window we are can create create class ArrowWindow and InputWindow and etc
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
}