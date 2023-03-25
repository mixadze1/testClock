using Assets._Scripts.Application.View;
using Assets._Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public class ArrowRaycaster : MonoBehaviour
    {
        [SerializeField] private ViewAlarmRaycastTime _viewAlarmText;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private EventSystem _eventSystem;

        private Camera _camera;

        private PointerEventData _pointerEventData;

        private IAlarmBehaviour _alarmBehaviour;

        private float _offsetRotation = 90;

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

            _alarmBehaviour.SetTime(_alarmBehaviour.GetParentTransform());
            _viewAlarmText.UpdateView();
        }

        private void DisableRaycast()
        {
            _alarmBehaviour = default;
        }

        private void RotationArrow()
        {
            var parent = _alarmBehaviour.GetParentTransform();
            var dir = Input.mousePosition - _camera.WorldToScreenPoint(parent.position);
            var rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - _offsetRotation;
            parent.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }

        private List<RaycastResult> GetRaycastUI()
        {
            if (_pointerEventData == null)
                _pointerEventData = new PointerEventData(_eventSystem);

            _pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(_pointerEventData, results);

            return results;
        }
    }
}