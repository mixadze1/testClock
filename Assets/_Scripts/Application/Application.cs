using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.Application
{
    public class Application : IApplicationHandler
    {
        private ClockView _clockView;
        private AlarmView _alarmView;
        private ViewAlarmRaycastTime _alarmRaycastTime;

        private Clock _clock;

        private List<ITimeObserver> _timeObserver = new List<ITimeObserver>();

        private List<IDataAlarm> _datas = new List<IDataAlarm>();

        private IAlarmHandler _alarmHandler;

        private SaveData _saveData;
        private DataAlarm _alarmData;

        private ITimeServiceHandler _timeService;

        public Application(ClockView clockView, AlarmView alarmView, ViewAlarmRaycastTime viewRaycast)
        {
            _alarmRaycastTime = viewRaycast;
            _datas.Add(_alarmRaycastTime);

            _alarmView = alarmView;
            _clockView = clockView;
            StartUpApplication();
        }

        private async void StartUpApplication()
        {
            GetSaves();
            InitializeTimeService();
            InitializeAlarm();
            InitializeClock();
            var time = await GetNewTimeResponse();

            SetResponseTime(time);
            InitializeData();
        }

        public void SetResponseTime(DateTime time)
        {
            foreach (var observer in _timeObserver)
            {
                observer.InitializeCorrectTime(time);
            }
        }

        private void GetSaves()
        {
            _saveData = new SaveData();
           _alarmData = _saveData.LoadData<DataAlarm>();
            if(_alarmData == null)
                _alarmData = new DataAlarm();
        }

        private void InitializeData()
        {
            foreach(var data in _datas)
            {
                data.GetData(_saveData, _alarmData);
            }
        }

        private void InitializeTimeService()
        {
            _timeService = new TimeService(applicationHandler:this);
        }

        private void InitializeAlarm()
        {
            var alarmHandler  = new Alarm(_alarmView);
            _alarmHandler = alarmHandler;
            _datas.Add(alarmHandler);
            _timeObserver.Add(alarmHandler);
        }

        private async Task<DateTime> GetNewTimeResponse()
        {
            return await _timeService.GetTime();
        }

        private void InitializeClock()
        {
            _clock = new Clock(_clockView, _alarmHandler);
            _timeObserver.Add(_clock);
        }
    }
}