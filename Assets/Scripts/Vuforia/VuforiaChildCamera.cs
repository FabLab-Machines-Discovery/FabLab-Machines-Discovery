using UnityEngine;

namespace Vuforia
{
    /*
     * This fixes the problem where child cameras of Vuforia AR Camera would have
     * a different projection matrix and different field of view than the AR Camera
     */
    public class VuforiaChildCamera : MonoBehaviour
    {
        private Camera _camera;
        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Start()
        {
            SetProjectionMatrixAndFOV();
        }

        private void SetProjectionMatrixAndFOV()
        {
            _camera.fieldOfView = Camera.main.fieldOfView;
            _camera.projectionMatrix = Camera.main.projectionMatrix;
        }
    }
}
