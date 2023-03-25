using Assets._Scripts.Application.Data;
using Assets._Scripts.Interfaces;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.Application.View
{
    public class ViewAlarmRaycastTime : MonoBehaviour, IDataAlarm
    {
        [SerializeField] private AlarmView _alarmView;
        [SerializeField] private TextMeshProUGUI _text;

        private IAlarmBehaviour _hour;
        private IAlarmBehaviour _minute;
        private IAlarmBehaviour _second;

        private void Awake()
        {
            _hour = _alarmView.Hour;
            _minute = _alarmView.Minute;
            _second = _alarmView.Second;
        }

        public void UpdateView()
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _hour.GetTime(), _minute.GetTime(), _second.GetTime());
            _text.text = dateTime.ToString("HH:mm:ss");
        }

        public void GetData(SaveData saveData, DataAlarm dataAlarm)
        {
            if (string.IsNullOrEmpty(dataAlarm.AlarmTime) || !dataAlarm.IsEnableAlarm)
                _text.text = "00:00:00";
            else
            {
                var time = dataAlarm.GetCorrectTime();
                _text.text = time.ToString("HH:mm:ss");
            }
        }
    }
}