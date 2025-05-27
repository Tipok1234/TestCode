using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private Vector3 offset;

        [SerializeField] private float followSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float sensitivity;
        [SerializeField] private float minVerticalAngle;
        [SerializeField] private float maxVerticalAngle;
        [SerializeField] private float lookHeightOffset ;
        
        [Header("Mouse Control")] 
        [SerializeField] private bool enableMouseRotation;
        
        private float _rotationY;
        private float _rotationX;
        
        private void FixedUpdate()
        {
            if (target == null || IsMousePointerOverUI()) return;

            if (enableMouseRotation)
            {
                _rotationY += Input.GetAxis("Mouse X") * sensitivity;
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
                _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);
            }

            Quaternion rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
            Vector3 desiredPosition = target.position + rotation * offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target.position + Vector3.up * lookHeightOffset);
        }

        public void Setup(Transform playerTarget)
        {
            target = playerTarget;
            
            SetupBaseState();
        }

        private void SetupBaseState()
        {
            if (target != null)
            {
                Vector3 angles = transform.eulerAngles;
                _rotationY = angles.y;
                _rotationX = angles.x;
            }
        }
        
        private bool IsMousePointerOverUI()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, raycastResults);
    
            return raycastResults.Count > 0;
        }
    }
}
