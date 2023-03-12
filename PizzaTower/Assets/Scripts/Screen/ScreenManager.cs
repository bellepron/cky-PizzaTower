using UnityEngine;

namespace PizzaTower.Screen
{
    public class ScreenManager : MonoBehaviour
    {
        Camera cam;

        float initOrthographicSize;
        float orthographicSize;
        [HideInInspector] public float sizeDiff;

        [SerializeField] Vector2 referenceResolution = new Vector2(1080, 1920);

        void Awake()
        {
            PrepareCamera();
        }

        private void PrepareCamera()
        {
            cam = GetComponent<Camera>();
            SetSize();
            SetInitPosition();
        }

        private void SetSize()
        {
            var referenceAspect = referenceResolution.x / referenceResolution.y;
            var refToCurrentConstant = referenceAspect / cam.aspect;

            initOrthographicSize = cam.orthographicSize;
            orthographicSize = cam.orthographicSize * refToCurrentConstant;
            cam.orthographicSize = orthographicSize;

            sizeDiff = initOrthographicSize - orthographicSize;
        }

        private void SetInitPosition()
        {
            transform.position = cam.transform.position - Vector3.up * sizeDiff;
        }
    }
}