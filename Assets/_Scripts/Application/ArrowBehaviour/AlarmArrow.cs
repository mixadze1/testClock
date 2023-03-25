using UnityEngine;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public abstract class AlarmArrow : MonoBehaviour
    {
        protected int _time;

        [SerializeField] protected Transform _parentTransform;

        public Transform GetParentTransform()
        {
            return _parentTransform;
        }
    }
}