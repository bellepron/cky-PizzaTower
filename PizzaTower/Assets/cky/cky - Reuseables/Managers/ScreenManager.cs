using UnityEngine;

namespace cky.Managers
{
    public class ScreenManager : MonoBehaviour
    {
        void Awake()
        {
            PrepareCamera();
        }

        private void PrepareCamera()
        {
            var cam = GetComponent<Camera>();
            var firstSize = cam.orthographicSize;
            var size = (18.45f / cam.aspect) * 0.5f;
            cam.orthographicSize = size;

            transform.position = cam.transform.position - Vector3.up * (firstSize - size);
        }
    }
}