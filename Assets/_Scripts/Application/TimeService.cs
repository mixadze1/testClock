using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using Assets._Scripts.Interfaces;

namespace Assets._Scripts.Application
{
    public class TimeService : ITimeServiceHandler
    {
        private IApplicationHandler _applicationHandler;

        private List<string> _urls = new List<string>();

        public TimeService(IApplicationHandler applicationHandler)
        {
            _applicationHandler = applicationHandler;
            InitializeUrls();
            ResponseNewTimeRemainingHours(hour: 1);
        }

        public async Task<DateTime> GetTime()
        {
            var dateTime = await ResponseTime();
            return dateTime;
        }

        private void InitializeUrls()
        {
            _urls.Add("http://worldtimeapi.org/api/timezone/Europe/Moscow");
            _urls.Add("https://www.timeapi.io/api/Time/current/zone?timeZone=Europe/Moscow");
        }

        private async void ResponseNewTimeRemainingHours(int hour)
        {
            var millisecondsInHour = 3600000;
            var parseHourToMiliSecond = hour * millisecondsInHour;

            while (true)
            {
                await Task.Delay(parseHourToMiliSecond);
                var newTime = await GetTime();
                _applicationHandler.SetResponseTime(newTime);
            }
        }

        public async Task<DateTime> ResponseTime()
        {
            foreach (string url in _urls)
            {
                var responseBody = await RequestUrl(url);
                if (responseBody != null)
                {
                    var response = ParseToDateTime(responseBody);
                    if (response != null)
                        return response;
                }
            }
            return DateTime.Now;
        }

        private async Task<string> RequestUrl(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                Debug.Log("Exception RequestUrl, maybe you are not have internet connection. " +
                   "\n What happen:\n" + ex.ToString() + "\n\n Use DateTime.Now: " + DateTime.Now);
                return null;
            }

        }

        private DateTime ParseToDateTime(string responseBody)
        {
            DateTime dateTime;

            var response = JsonUtility.FromJson<TimeData>(responseBody);
            bool isDateTimeValid = DateTime.TryParse(response.Datetime, out dateTime);
            if (isDateTimeValid)
                return dateTime;

            isDateTimeValid = DateTime.TryParse(response.datetime, out dateTime);
            if (isDateTimeValid)
                return dateTime;

            Debug.Log("IsNotValidDateUrl, use DateTime.Now");
            return DateTime.Now;
        }
    }

    class TimeData
    {
        public string Datetime;
        public string datetime;
    }
}