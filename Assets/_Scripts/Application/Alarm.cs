using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;

public class Alarm : ITimeObserver, IDataAlarm, IAlarmHandler
{
    private SaveData _saveData;
    private DataAlarm _alarmData;

    private AlarmView _alarmView;

    private DateTime _time;

    public List<IAlarmBehaviour> AlarmBehaviourArrow = new List<IAlarmBehaviour>();

    public Alarm(AlarmView alarmView)
    {
        _alarmView = alarmView;
        _alarmView.Initialize(alarmHandler:this);
        CreateAlarmBehaviour();
    }

    private void CreateAlarmBehaviour()
    {
        AlarmBehaviourArrow.Add(_alarmView.Hour);
        AlarmBehaviourArrow.Add(_alarmView.Minute);
        AlarmBehaviourArrow.Add(_alarmView.Second);
    }

    public void InitializeCorrectTime(DateTime time)
    {
        _time = time;
    }

    private void InitializeAlarmArrow(DateTime time)
    {
        foreach(var alarm in AlarmBehaviourArrow)
        {
            alarm.Initialize(time, _alarmView);
        }
    }

    public void GetData(SaveData saveData, DataAlarm dataAlarm)
    {
        _saveData = saveData;
        _alarmData = dataAlarm;
        InitializeAlarm();
    }

    private bool IsEnableAlarm()
    {
        if (_alarmData.IsEnableAlarm)
            return true;
        return false;
    }

    public void RemainingAlarm(DateTime time)
    {
        if(_alarmData != null && IsEnableAlarm())
        {
            var alarmTime = _alarmData.GetCorrectTime();
            Debug.Log(time);

            if (time.Hour  == alarmTime.Hour && time.Minute == alarmTime.Minute && time.Second == alarmTime.Second)
            {
                Debug.Log("ALARM!!!");
                AlarmActivate();    
            }
        }
           
    }

    private void AlarmActivate()
    {
        _alarmView.ActivateAlarm.gameObject.SetActive(true);
    }

    private void InitializeAlarm()
    {
        if(_alarmData.AlarmTime != null && _alarmData.IsEnableAlarm)
        {
            _alarmView.AlarmContainer.gameObject.SetActive(true);
            EnableAlarm(_alarmData.GetCorrectTime());
        }
        else
        {
            DisableAlarm();
        }
    }

    private void EnableAlarm(DateTime time)
    {
         var alarmTime = _alarmData.GetCorrectTime();
        Debug.Log(alarmTime.Hour);
        SetAlarm(alarmTime.Hour, alarmTime.Minute, alarmTime.Second);
        InitializeAlarmArrow(time);
    }

    private void SetAlarm(int hour, int minute, int second)
    {
        _alarmView.AlarmContainer.gameObject.SetActive(true);
        _alarmData.IsEnableAlarm = true;
        DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
        _alarmData.SaveAlarm(dateTime);
        _alarmView.UpdateView(dateTime);
        _saveData.Save(_alarmData);
       var time = _saveData.LoadData<DataAlarm>();
    }

    public void EnableAlarmWithArrow()
    {
        var alarmHour = AlarmBehaviourArrow[0].GetTime(); //hour
        var alarmMinute = AlarmBehaviourArrow[1].GetTime();//minute
        var alarmSecond = AlarmBehaviourArrow[2].GetTime(); // second

        SetAlarm(alarmHour, alarmMinute, alarmSecond);
    }

    public void EnableAlarmWithInput()
    {
        var alarmHour = _alarmView.HourInput.GetTime();
        var alarmMinute = _alarmView.MinuteInput.GetTime();
        var alarmSecond = _alarmView.SecondInput.GetTime();
        SetAlarm(alarmHour, alarmMinute, alarmSecond);
    }

    public void DisableAlarm()
    {
        _alarmData.IsEnableAlarm = false;
        _alarmView.AlarmContainer.gameObject.SetActive(false);
        _saveData.Save(_alarmData);
    }
}

public class DataAlarm
{
    public bool IsEnableAlarm;
    public string AlarmTime;

    public void SaveAlarm(DateTime dateTime)
    {
        Debug.Log(dateTime);
        AlarmTime = dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffzzz");   
    }

    public DateTime GetCorrectTime()
    {
        DateTime dateTime = DateTime.ParseExact(AlarmTime, "yyyy-MM-dd'T'HH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture);
        Debug.Log(dateTime);
        return dateTime;
    }

}
