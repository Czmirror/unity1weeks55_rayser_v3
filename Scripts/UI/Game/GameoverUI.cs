using System;
using DG.Tweening;
using Event;
using UniRx;
using UnityEngine;

namespace UI.Game
{
    public class GameoverUI : MonoBehaviour
    {
        [SerializeField] private RectTransform gameoverUIRectTransform;
        [SerializeField] private CanvasGroup gameoverUICanvasGroup;
        [SerializeField] private CanvasGroup MissionFailedUICanvasGroup;
        [SerializeField] private CanvasGroup ButtonsUICanvasGroup;
        [SerializeField] private GameObject canvasGame;

        private Vector3 _inUIPosition;
        private Vector3 _outUIPosition;

        private void Start()
        {
            InitializeUI();
            MessageBroker.Default.Receive<Gameover>().Subscribe(x => Gameover()).AddTo(this);
        }

        private void InitializeUI()
        {
            gameoverUICanvasGroup.alpha = 0;
            _inUIPosition = new Vector3(0, 0, 0);
            _outUIPosition = new Vector3(2000, 0, 0);
            gameoverUIRectTransform.localPosition = _outUIPosition;
        }

        private void Gameover()
        {
            canvasGame.SetActive(false);

            // DOTweenシーケンスセット
            var sequence = DOTween.Sequence();

            gameoverUIRectTransform.localPosition = _inUIPosition;
            sequence
                .Append(gameoverUICanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            sequence
                .Append(MissionFailedUICanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            sequence
                .Append(ButtonsUICanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f)
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            sequence.Restart();
        }
    }
}
