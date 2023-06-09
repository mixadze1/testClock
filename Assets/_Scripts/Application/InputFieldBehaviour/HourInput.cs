using Assets._Scripts.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.Application.InputFieldBehaviour
{
    public class HourInput : MonoBehaviour, IAlarmInputBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private int _value;

        private int _maxValueHour = 23;

        private string _text;

        public int GetTime()
        {
            return _value;
        }

        public void SetTime()
        {
            _text = _inputField.text;
            if (string.IsNullOrEmpty(_text))
                return;

            int result = int.Parse(_text);
            _value = result;

            if (result > _maxValueHour)
            {
                _value = _maxValueHour;
                _inputField.text = _value.ToString();
            }
            if (result < 0)
            {
                _value = 0;
                _inputField.text = _value.ToString();
            }
        }
    }
}