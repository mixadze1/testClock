using UnityEngine;

namespace Assets._Scripts.Application.ArrowBehaviour
{
    public abstract class AlarmArrow : MonoBehaviour
    {
        [SerializeField] protected Transform _parentTransform;

        protected int _time;

        public Transform GetParentTransform()
        {
            return _parentTransform;
        }
    }
}