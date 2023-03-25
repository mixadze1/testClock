using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public class ArrowRaycaster : MonoBehaviour
    {
        [SerializeField] private ViewAlarmRaycastTime _viewAlarmText;

        [SerializeField] private GraphicRaycaster m_Raycaster;
        [SerializeField] private EventSystem m_EventSystem;

        private Camera _camera;

        private PointerEventData m_PointerEventData;

        private IAlarmBehaviour _alarmBehaviour;

        public void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var results = GetRaycastUI();

                if (results.Count == 0)
                    return;

                var hit = results[0];

                if (hit.gameObject.TryGetComponent(out IAlarmBehaviour alarmBehaviour) && _alarmBehaviour != alarmBehaviour)
                {
                    _alarmBehaviour = alarmBehaviour;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                SetTime();
                DisableRaycast();
            }

            if (_alarmBehaviour != null)
            {
                RotationArrow();
                SetTime();
            }
        }

        private void SetTime()
        {
            if (_alarmBehaviour == null)
                return;

            Debug.Log("SetTime");
            _alarmBehaviour.SetTime(_alarmBehaviour.GetParentTransform());
            _viewAlarmText.UpdateView();
        }

        private void DisableRaycast()
        {
            _alarmBehaviour = null;
        }

        private void RotationArrow()
        {
            var parent = _alarmBehaviour.GetParentTransform();
            var dir = Input.mousePosition - _camera.WorldToScreenPoint(parent.position);
            var rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            parent.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
            parent.rotation = Quaternion.Euler(parent.rotation.eulerAngles.x, parent.rotation.eulerAngles.y, parent.rotation.eulerAngles.z - 90);
            Debug.Log(parent.rotation.eulerAngles);
        }

        private List<RaycastResult> GetRaycastUI()
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            return results;
        }
    }
}