using System;
using System.Globalization;
using UnityEngine;

namespace Assets._Scripts.Application.Data
{
    public class DataAlarm
    {
        public bool IsEnableAlarm;
        public string AlarmTime;

        public void SaveAlarm(DateTime dateTime)
        {
            AlarmTime = dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffzzz");
        }

        public DateTime GetCorrectTime()
        {
            DateTime dateTime = DateTime.ParseExact(AlarmTime, "yyyy-MM-dd'T'HH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}