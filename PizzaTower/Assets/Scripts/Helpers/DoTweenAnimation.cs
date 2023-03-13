using DG.Tweening;
using UnityEngine;

namespace PizzaTower.Helpers
{
    public static class DoTweenAnimation
    {
        public static void NewFloorAnimation(this Transform newFloorTr, Vector3 pos, float floorOpeningTime)
        {
            newFloorTr.DOMoveY(pos.y - 0.5f, 0);
            newFloorTr.DOMoveY(pos.y, floorOpeningTime);
            newFloorTr.DOScaleY(0, 0);
            newFloorTr.DOScaleY(1, floorOpeningTime).SetEase(Ease.InSine);
        }

        public static void TopFloorAnimation(this Transform topFloorTr, Vector3 pos, float topFloorOffsetY, float floorOpeningTime)
        {
            topFloorTr.DOMoveY(pos.y - topFloorOffsetY, 0);
            topFloorTr.DOMoveY(pos.y, floorOpeningTime).SetEase(Ease.InSine);
        }

        public static Tween StaffOpeningAnimation(this Transform staffTr, Vector3 scale, float chefOpeningTime)
        {
            Sequence sequence = DOTween.Sequence();

            staffTr.localScale = Vector3.zero;

            sequence.Append(staffTr.DOScale(scale * 1.0f, chefOpeningTime * 0.65f).SetEase(Ease.InSine));
            sequence.Append(staffTr.DOScale(scale * 1.1f, chefOpeningTime * 0.25f).SetEase(Ease.InSine));
            sequence.Append(staffTr.DOScale(scale, chefOpeningTime * 0.1f).SetEase(Ease.OutSine));

            return sequence;
        }

        public static Tween TableOpeningAnimation(this Transform tableTr, Vector3 scale, float tableOpeningTime)
        {
            Sequence sequence = DOTween.Sequence();

            var scaleY = scale.y;
            tableTr.localScale = new Vector3(tableTr.localScale.x, 0, 0);

            sequence.Append(tableTr.DOScaleY(scaleY, tableOpeningTime * 0.65f).SetEase(Ease.InSine));
            sequence.Append(tableTr.DOScale(scale * 1.2f, tableOpeningTime * 0.25f).SetEase(Ease.InSine));
            sequence.Append(tableTr.DOScale(scale, tableOpeningTime * 0.1f).SetEase(Ease.OutSine));

            return sequence;
        }

        public static Tween CanvasYellowBarAnimation(this Transform itemTr, float time)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(itemTr.DOScaleX(1, time * 0.65f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one * 1.075f, time * 0.25f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one, time * 0.1f).SetEase(Ease.OutSine));

            return sequence;
        }

        public static Tween CanvasButtonAnimation(this Transform itemTr, float time)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(itemTr.DOScale(Vector3.one, time * 0.65f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one * 1.1f, time * 0.25f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one, time * 0.1f).SetEase(Ease.OutSine));

            return sequence;
        }

        public static void CanvasStarAnimation(this Transform itemTr, float time)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(itemTr.DOScale(Vector3.one, time * 0.65f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one * 1.25f, time * 0.25f).SetEase(Ease.InSine));
            sequence.Append(itemTr.DOScale(Vector3.one, time * 0.1f).SetEase(Ease.OutSine));
        }

        public static void BoostButtonOpeningAnimation(this Transform itemTr,float time)
        {
            itemTr.transform.localScale = Vector3.zero;
            itemTr.transform.DOScale(1, time);
        }
    }
}