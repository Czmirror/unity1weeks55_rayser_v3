using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Title
{
    public class ButtonManual : MonoBehaviour
    {
        [SerializeField] private CanvasGroup menuButtonsCanvasGroup;
        [SerializeField] private RectTransform menuButtonsRectTransform;
        [SerializeField] private CanvasGroup manualCanvasGroup;
        [SerializeField] private RectTransform manualRectTransform;
        [SerializeField] private CanvasGroup manualInsideButtonsCanvasGroup;
        [SerializeField] private CanvasGroup manualHeaderImageCanvasGroup;
        [SerializeField] private CanvasGroup controlsCanvasGroup;
        [SerializeField] private RectTransform controlsRectTransform;
        [SerializeField] private CanvasGroup storyCanvasGroup;
        [SerializeField] private RectTransform storyRectTransform;
        [SerializeField] private CanvasGroup charactersCanvasGroup;
        [SerializeField] private RectTransform charactersRectTransform;
        [SerializeField] private CanvasGroup gameScreenCanvasGroup;
        [SerializeField] private RectTransform gameScreenRectTransform;

        private Vector3 _initialMenuButtonPosition = Vector3.zero;
        private Vector3 _initialManualPosition = Vector3.zero;
        private Vector2 _initialManualUISizeDelta = Vector2.zero;
        private Vector3 _inUIPosition;
        private Vector3 _outUIPosition;

        private void InitializeManualUI()
        {
            manualCanvasGroup.alpha = 0;
            manualRectTransform.sizeDelta = Vector2.zero;
            manualInsideButtonsCanvasGroup.alpha = 0;
            manualHeaderImageCanvasGroup.alpha = 0;
            controlsCanvasGroup.alpha = 0;
            storyCanvasGroup.alpha = 0;
            charactersCanvasGroup.alpha = 0;
            gameScreenCanvasGroup.alpha = 0;

            _inUIPosition = new Vector3(0, 0, 0);
            _outUIPosition = new Vector3(2000, 0, 0);
            manualRectTransform.position = _outUIPosition;
        }

        private void InitializeMenuUI()
        {
        }

        private void Start()
        {
            _initialMenuButtonPosition = menuButtonsRectTransform.position;
            _initialManualUISizeDelta = manualRectTransform.sizeDelta;
            _initialManualPosition = manualRectTransform.position;

            InitializeManualUI();
        }

        public void PushManualButton()
        {
            if (menuButtonsCanvasGroup.alpha == 0)
            {
                return;
            }

            InitializeManualUI();

            // DOTweenシーケンスセット
            var sequence = DOTween
                .Sequence()
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            // メニューボタン非表示
            sequence
                .Append(menuButtonsCanvasGroup.DOFade(0f, 0.2f))
                .Join(menuButtonsRectTransform.DOMoveX(1000, 0.1f))
                .AppendInterval(0.1f);

            // マニュアル表示
            manualRectTransform.position = _initialManualPosition;
            sequence
                .Append(manualCanvasGroup.DOFade(1f, 0.5f))
                .Join(manualRectTransform.DOSizeDelta(new Vector2(_initialManualUISizeDelta.x, 2), 1f))
                .Append(manualRectTransform.DOSizeDelta(
                    new Vector2(_initialManualUISizeDelta.x, _initialManualUISizeDelta.y), 1f))
                .AppendInterval(0.5f);

            // マニュアル見出しイメージ表示
            sequence
                .Append(manualHeaderImageCanvasGroup.DOFade(1f, 0.3f))
                .AppendInterval(0.3f);

            // マニュアル内ボタン表示
            sequence
                .Append(manualInsideButtonsCanvasGroup.DOFade(1f, 0.3f))
                .AppendInterval(0.3f)
                .OnComplete(()=>ShowUI(controlsCanvasGroup, controlsRectTransform));

            sequence.Restart();
        }


        public void PushManualCloseButton()
        {
            // DOTweenシーケンスセット
            var sequence = DOTween
                .Sequence()
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            // マニュアル内ボタン非表示
            sequence
                .Append(manualInsideButtonsCanvasGroup.DOFade(0f, 0.1f))
                .AppendInterval(0.2f);

            // 操作説明、ストーリー、キャラクター非表示
            HiddenInsideUI();

            // マニュアル見出しイメージ非表示
            sequence
                .Append(manualHeaderImageCanvasGroup.DOFade(0f, 0.1f))
                .AppendInterval(0.2f);

            // マニュアル非表示
            sequence
                .Append(manualRectTransform.DOSizeDelta(new Vector2(_initialManualUISizeDelta.x, 2), 1f))
                .Append(manualCanvasGroup.DOFade(0f, 0.1f))
                .Join(manualRectTransform.DOSizeDelta(new Vector2(0, 2), 1f))
                .AppendInterval(0.2f)
                .AppendCallback(() => { manualRectTransform.position = _outUIPosition; });

            // メニューボタン表示
            sequence
                .Append(menuButtonsCanvasGroup.DOFade(1f, 0.1f))
                .Join(menuButtonsRectTransform.DOMoveX(_initialMenuButtonPosition.x, 0.1f))
                .AppendInterval(0.1f);
            sequence.Restart();
        }

        private void HiddenInsideUI()
        {
            // DOTweenシーケンスセット
            var sequence = DOTween
                .Sequence()
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            // 操作説明、ストーリー、キャラクター非表示
            sequence
                .Append(controlsCanvasGroup.DOFade(0f, 0.1f))
                .Join(storyCanvasGroup.DOFade(0f, 0.1f))
                .Join(charactersCanvasGroup.DOFade(0f, 0.1f))
                .Join(gameScreenCanvasGroup.DOFade(0f, 0.1f))
                .AppendInterval(0.2f)
                .AppendCallback(() =>
                {
                    controlsRectTransform.localPosition = _outUIPosition;
                    storyRectTransform.localPosition = _outUIPosition;
                    charactersRectTransform.localPosition = _outUIPosition;
                    gameScreenRectTransform.localPosition = _outUIPosition;
                });

            sequence.Restart();
        }

        private void ShowUI(CanvasGroup canvasGroup, RectTransform rectTransform)
        {
            // 表示中UIの場合は処理を実行しない
            if (canvasGroup.alpha == 1)
            {
                return;
            }

            // 現在表示中のUIを非表示にする
            HiddenInsideUI();

            // DOTweenシーケンスセット
            var sequence = DOTween
                .Sequence()
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            // UI表示
            sequence
                .Append(canvasGroup.DOFade(1f, 0.2f))
                .AppendInterval(0.3f)
                .AppendCallback(() => { rectTransform.localPosition = _inUIPosition; });

            sequence.Restart();
        }

        public void PushControlsButton()
        {
            ShowUI(controlsCanvasGroup, controlsRectTransform);
        }

        public void PushStoryButton()
        {
            ShowUI(storyCanvasGroup, storyRectTransform);
        }

        public void PushCharactersButton()
        {
            ShowUI(charactersCanvasGroup, charactersRectTransform);
        }

        public void PushScreenButton()
        {
            ShowUI(gameScreenCanvasGroup, gameScreenRectTransform);
        }
    }
}
