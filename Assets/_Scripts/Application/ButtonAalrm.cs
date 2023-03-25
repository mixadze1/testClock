using UnityEngine;

namespace Assets._Scripts.Application
{
    public class ButtonAalrm : MonoBehaviour
    {
        [SerializeField] private RectTransform _alarmView;

        public void ActivateButton()
        {
            if (_alarmView.gameObject.activeSelf)
                _alarmView.gameObject.SetActive(false);
            else
                _alarmView.gameObject.SetActive(true);
        }
    }
}