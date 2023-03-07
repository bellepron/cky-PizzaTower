using DG.Tweening;
using UnityEngine;

namespace PizzaTower.Helpers
{
    public static class DoTweenAnimation
    {


        public static Tween ChefOpeningAnimation(this Transform chefTr, float chefOpeningTime)
        {
            Sequence sequence = DOTween.Sequence();

            var scale = chefTr.localScale;
            chefTr.localScale = Vector3.zero;
            sequence.Append(chefTr.DOScale(scale * 1.0f, chefOpeningTime * 0.65f).SetEase(Ease.InSine));
            sequence.Append(chefTr.DOScale(scale * 1.15f, chefOpeningTime * 0.25f).SetEase(Ease.InSine));
            sequence.Append(chefTr.DOScale(scale, chefOpeningTime * 0.1f).SetEase(Ease.OutSine));

            return sequence;
        }

        public static void TableOpeningAnimation(this Transform tableTr, float tableOpeningTime)
        {
            Sequence sequence = DOTween.Sequence();

            var scale = tableTr.localScale;
            var scaleY = scale.y;
            tableTr.localScale = new Vector3(tableTr.localScale.x, 0, 0);
            sequence.Append(tableTr.DOScaleY(scaleY, tableOpeningTime * 0.65f).SetEase(Ease.InSine));
            sequence.Append(tableTr.DOScale(scale * 1.2f, tableOpeningTime * 0.25f).SetEase(Ease.InSine));
            sequence.Append(tableTr.DOScale(scale, tableOpeningTime * 0.1f).SetEase(Ease.OutSine));
        }
    }
}