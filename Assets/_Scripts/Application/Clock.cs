using Assets._Scripts.Application.ClockBehaviour;
using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Application
{
    public class Clock : IClockHandler, ITimeObserver
    {
        private List<IClockBehaviour> _clockBehaviours = new List<IClockBehaviour>();
        private IAlarmHandler _alarmHandler;

        private ClockView _clockView;
        private DateTime _time;

        public Clock(ClockView clockView, IAlarmHandler alarmHandler)
        {
            _alarmHandler = alarmHandler;
            _clockView = clockView;
            InitializeClockBehaviour();
        }

        public void InitializeCorrectTime(DateTime time)
        {
            Debug.Log("SetCorrectTime");
            _time = time;
            Updater();
        }

        private async void Updater()
        {
            var secondInMs = 1000;
            var second = 1;

            while (true)
            {
                UpdateTime(_time);
                _alarmHandler.RemainingAlarm(_time);
                await Task.Delay(secondInMs);
                _time = _time.AddSeconds(second);
            }
        }

        private void InitializeClockBehaviour()
        {
            _clockBehaviours.Add(new Hour());
            _clockBehaviours.Add(new Minute());
            _clockBehaviours.Add(new Second());
            _clockBehaviours.Add(new DigitalTime());
        }

        private void UpdateTime(DateTime time)
        {
            foreach (var c in _clockBehaviours)
            {
                c.UpdateTime(time, _clockView);
            }
        }
    }
}