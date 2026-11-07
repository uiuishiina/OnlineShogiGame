using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;


namespace KTC.Title
{
    public static class TitleUIAnimation
    {
        const float MAX_TWEEN_TIME = 2.0f;

        [Range(0.0f, MAX_TWEEN_TIME)] static float _settingBGTweenTime = 0.5f;


        /// <summary>
        /// LocalScale X 拡大Tween作成関数
        /// </summary>
        /// <param name="transform">拡大するRectTransorm</param>
        /// <param name="callBack">終了時呼び出し関数</param>
        /// <param name="endValue">最終的な拡大率</param>
        /// <returns>作成したTween</returns>
        public static TweenerCore<Vector3, Vector3, VectorOptions> ExpansionRectX(RectTransform transform, TweenCallback callBack = null, float endValue = 1)
        {
            return transform.DOScaleX(endValue, _settingBGTweenTime).OnComplete(callBack);
        }

        /// <summary>
        /// LocalScale Y 拡大Tween作成関数
        /// </summary>
        /// <param name="transform">拡大するRectTransorm</param>
        /// <param name="callBack">終了時呼び出し関数</param>
        /// <param name="endValue">最終的な拡大率</param>
        /// <returns>作成したTween</returns>
        public static TweenerCore<Vector3, Vector3, VectorOptions> ExpansionRectY(RectTransform transform, TweenCallback callBack = null, float endValue = 1)
        {
            return transform.DOScaleY(endValue, _settingBGTweenTime).OnComplete(callBack);
        }

    }
}
