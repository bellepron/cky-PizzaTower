using PizzaTower.Floors;
using PizzaTower.Managers;
using System.Collections;
using UnityEngine;

namespace PizzaTower.Screen
{
    [RequireComponent(typeof(ScreenManager))]
    public class ScreenMover : MonoBehaviour
    {
        ScreenManager _screenManager;
        TopFloorController _topFloorController;
        [SerializeField] ScreenSettings _screenSettings;

        [SerializeField] float offsetBetweenTopFloorAndCamera = 8.75f;

        Vector3 _prevMousePos;
        Vector3 _currentMousePos;
        float _initPosY;
        float _initPosZ;
        float _maxPosY;
        bool _pressing = false;
        WaitForSeconds _scrollHoldDuration;
        float _screenHeightMultiplier;

        float _sizeDiff;

        private void Start()
        {
            _topFloorController = TopFloorController.Instance;
            _screenManager = GetComponent<ScreenManager>();
            _sizeDiff = _screenManager.sizeDiff;

            _initPosY = transform.position.y;
            _maxPosY = _initPosY;
            _initPosZ = transform.position.z;
            _screenHeightMultiplier = 1f / UnityEngine.Screen.height;

            _scrollHoldDuration = new WaitForSeconds(_screenSettings.ScrollHoldDuration);

            EventManager.AddFloor += WhenFloorAdded;
        }

        private void WhenFloorAdded(int floorCount)
        {
            var targetY = _topFloorController.GetTargetHeight() - offsetBetweenTopFloorAndCamera + _sizeDiff;

            if (_initPosY > targetY) return;

            transform.position = new Vector3(0, targetY, _initPosZ);
            _maxPosY = targetY;
        }

        private void LateUpdate()
        {
            _currentMousePos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Delay());
                _prevMousePos = _currentMousePos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _pressing = false;
                _prevMousePos = _currentMousePos;
                StopAllCoroutines();
            }

            if (_pressing)
            {
                var direction = _currentMousePos - _prevMousePos;
                direction.y = Mathf.Clamp(direction.y, -_screenSettings.SwipePixelClamp, _screenSettings.SwipePixelClamp);
                direction.x = 0;

                transform.Translate(direction * Time.deltaTime * _screenHeightMultiplier * _screenSettings.SwipeSpeed);
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _initPosY, _maxPosY), transform.position.z);
            }
        }

        IEnumerator Delay()
        {
            yield return _scrollHoldDuration;
            _pressing = true;
        }
    }
}