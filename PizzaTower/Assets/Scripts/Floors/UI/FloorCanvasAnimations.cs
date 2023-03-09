using DG.Tweening;
using PizzaTower.Helpers;
using PizzaTower.Managers;
using System.Collections;
using UnityEngine;

namespace PizzaTower.Floors.UI
{
    public class FloorCanvasAnimations : MonoBehaviour
    {
        [SerializeField] Transform yellowBarTr;
        [SerializeField] Transform buttonHolderTr;
        [SerializeField] Transform[] starTrs;

        FloorSettings _floorSettings;

        public void Initialize()
        {
            _floorSettings = LevelManager.Instance.levelSettings.FloorSettings;

            var scaleZero = Vector3.zero;
            yellowBarTr.localScale = new Vector3(0, yellowBarTr.localScale.y, 0);
            buttonHolderTr.localScale = scaleZero;

            foreach (var star in starTrs)
                star.localScale = scaleZero;

            DOVirtual.DelayedCall(_floorSettings.FloorOpeningTime, () =>
                      {
                          var seq = DOTween.Sequence();
                          seq.Append(OpenYellowBar());
                          seq.Append(OpenButtons());
                          seq.OnComplete(() => StartCoroutine(OpenStars()));
                      });


        }

        private Tween OpenYellowBar()
        {
            return yellowBarTr.CanvasYellowBarAnimation(_floorSettings.CanvasYellowBarOpeningTime);
        }

        private Tween OpenButtons()
        {
            return buttonHolderTr.CanvasButtonAnimation(_floorSettings.CanvasUpgradeButtonOpeningTime);
        }

        IEnumerator OpenStars()
        {
            var delayWfs = new WaitForSeconds(_floorSettings.CanvasStarsOpeningInterval);

            for (int i = 0; i < starTrs.Length; i++)
            {
                starTrs[i].CanvasStarAnimation(_floorSettings.CanvasStarsOpeningTime);

                yield return delayWfs;
            }
        }
    }
}