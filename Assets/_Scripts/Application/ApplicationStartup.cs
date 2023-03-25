using UnityEngine;

namespace Assets._Scripts.Application
{
    public class ApplicationStartup : MonoBehaviour
    {
        [SerializeField] private ViewAlarmRaycastTime _viewRaycast;
        [SerializeField] private ClockView _clockView;
        [SerializeField] private AlarmView _alarmView;

        private void Start()
        {
            new Application(_clockView, _alarmView, _viewRaycast);
        }
    }
}