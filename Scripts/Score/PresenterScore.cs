using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UniRx;

namespace Score
{
    /// <summary>
    /// スコア表示処理
    /// </summary>
    public class PresenterScore : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;

        /// <summary>
        /// 更新対象UI
        /// </summary>
        [SerializeField] private TextMeshProUGUI scoreUI;

        /// <summary>
        /// UIアニメーション時間
        /// </summary>
        [SerializeField] private float tweenTime = 0.1f;

        private void Start()
        {
            _scoreCounter.ScoreObservable.Subscribe(x => RefreshUI(x)).AddTo(this);
        }

        private void RefreshUI(float shield)
        {
            float valueFrom = int.Parse(scoreUI.text, CultureInfo.InvariantCulture.NumberFormat);
            float valueTo = shield;
            var scoreUITween = DOTween.To(
                    () => valueFrom,
                    x => { scoreUI.text = x.ToString(); },
                    valueTo,
                    tweenTime
                )
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            scoreUITween.Restart();
        }
    }
}
