using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HourInput : MonoBehaviour, IInputBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private int _value;

    private string _text;

    public int GetTime()
    {
        return _value;
    }

    public void SetTime()
    {
        _text = _inputField.text;
        Debug.Log(_text);
        if (string.IsNullOrEmpty(_text))
            return;

        int result = int.Parse(_text);
        _value = result;
   

        if (result >= 24)
        {
            _value = 23;
            _inputField.text = _value.ToString();
        }
        if (result < 0)
        {
            _value = 0;
            _inputField.text = _value.ToString();
        }
    }
}
