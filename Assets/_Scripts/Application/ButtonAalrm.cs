using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAalrm : MonoBehaviour
{
    [SerializeField] private RectTransform _alarmView;

    public void ActivateButton()
    {
        if(_alarmView.gameObject.activeSelf)
            _alarmView.gameObject.SetActive(false);
        else
            _alarmView.gameObject.SetActive(true);
    }
}
