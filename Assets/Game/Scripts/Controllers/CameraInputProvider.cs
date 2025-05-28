using UnityEngine;
using Interfaces;

namespace Controllers
{
    public class CameraInputProvider : MonoBehaviour, ICameraInputProvider
    {
        public Vector2 GetMouseInput()
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}
