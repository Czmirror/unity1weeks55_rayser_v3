using System;
using DG.Tweening;
using Rayser.CustomEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRM;

namespace UI.Title
{
    public class ButtonStart : MonoBehaviour
    {
        [SerializeField] private CanvasGroup menuButtonsCanvasGroup;
        [SerializeField] private RectTransform menuButtonsRectTransform;
        [SerializeField] private CanvasGroup gameStartUICanvasGroup;
        [SerializeField] private RectTransform gameStartUIRectTransform;
        [SerializeField] private CanvasGroup missionWindowCanvasGroup;
        [SerializeField] private RectTransform missionWindowRectTransform;
        [SerializeField] private CanvasGroup missionLightUITopCanvasGroup;
        [SerializeField] private RectTransform missionLightUITopRectTransform;
        [SerializeField] private CanvasGroup missionLightUIBottomCanvasGroup;
        [SerializeField] private RectTransform missionLightUIBottomRectTransform;
        [SerializeField] private CanvasGroup faceWindowCanvasGroup;
        [SerializeField] private CanvasGroup roydFaceWindowCanvasGroup;
        [SerializeField] private CanvasGroup sophieFaceWindowCanvasGroup;
        [SerializeField] private CanvasGroup roydTalkWindowCanvasGroup;
        [SerializeField] private TextMeshProUGUI roydTextMeshPro;
        [SerializeField] private CanvasGroup sophieTalkWindowCanvasGroup;
        [SerializeField] private TextMeshProUGUI sophieTextMeshPro;

        [SerializeField] private GameObject roydCamera;
        [SerializeField] private GameObject sophieCamera;

        [SerializeField] private MouthAnimation roydMouthAnimation;
        [SerializeField] private MouthAnimation sophieMouthAnimation;

        [SerializeField] private SceneObject gameScene;

        private Vector3 _initialGameStartUIPosition = Vector3.zero;
        private Vector2 _initialGameStartUISizeDelta = Vector2.zero;
        private Vector3 _initialMissionWindowPosition = Vector3.zero;
        private Vector2 _initialMissionWindowSizeDelta = Vector2.zero;
        private Vector3 _inUIPosition;
        private Vector3 _outUIPosition;

        private String _messege;
        private float _message_speed = 0.1f;

        private void InitializeUI()
        {
            gameStartUICanvasGroup.alpha = 0;
            gameStartUIRectTransform.sizeDelta = Vector2.zero;
            missionWindowCanvasGroup.alpha = 0;
            missionWindowRectTransform.sizeDelta = Vector2.zero;
            // faceWindowCanvasGroup.alpha = 0;
            roydTalkWindowCanvasGroup.alpha = 0;
            sophieTalkWindowCanvasGroup.alpha = 0;
            roydFaceWindowCanvasGroup.alpha = 0;
            sophieFaceWindowCanvasGroup.alpha = 0;
            TalkMessageReset(roydTextMeshPro);
            TalkMessageReset(sophieTextMeshPro);

            _inUIPosition = new Vector3(0, 0, 0);
            _outUIPosition = new Vector3(2000, 0, 0);
            gameStartUIRectTransform.position = _outUIPosition;
        }

        private void Start()
        {
            _initialGameStartUIPosition = gameStartUIRectTransform.position;
            _initialGameStartUISizeDelta = gameStartUIRectTransform.sizeDelta;
            _initialMissionWindowPosition = missionWindowRectTransform.position;
            _initialMissionWindowSizeDelta = missionWindowRectTransform.sizeDelta;
            InitializeUI();
        }

        private void TalkMessageReset(TextMeshProUGUI textMeshProUGUI)
        {
            textMeshProUGUI.text = String.Empty;
        }

        public void PushButton()
        {
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

            // GameStartUI表示
            gameStartUIRectTransform.position = _initialGameStartUIPosition;
            sequence
                .Append(gameStartUICanvasGroup.DOFade(1f, 0.5f))
                .Join(gameStartUIRectTransform.DOSizeDelta(new Vector2(_initialGameStartUISizeDelta.x, 2), 1f))
                .Append(gameStartUIRectTransform.DOSizeDelta(
                    new Vector2(_initialGameStartUISizeDelta.x, _initialGameStartUISizeDelta.y), 1f))
                .AppendInterval(0.5f);

            // Mission表示
            missionWindowRectTransform.position = _initialMissionWindowPosition;
            sequence
                .Append(missionWindowCanvasGroup.DOFade(1f, 0.5f))
                .Join(missionWindowRectTransform.DOSizeDelta(new Vector2(_initialMissionWindowSizeDelta.x, 2), 1f))
                .Append(missionWindowRectTransform.DOSizeDelta(
                    new Vector2(_initialMissionWindowSizeDelta.x, _initialMissionWindowSizeDelta.y), 0.2f))
                .AppendInterval(0.5f);

            // Mission光演出
            sequence
                .Append(missionLightUITopRectTransform.DOLocalMoveX(1000, 0.5f))
                .Join(missionLightUIBottomRectTransform.DOLocalMoveX(-1000, 0.5f))
                .AppendInterval(0.5f);

            // ロイドカメラ有効
            roydCamera.SetActive(true);

            // ロイド顔ウインドウ表示
            sequence
                .Append(roydFaceWindowCanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            // ロイドトークウインドウ表示
            sequence
                .Append(roydTalkWindowCanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            _messege = "こちらロイド、宇宙海賊の戦艦付近に到着した。";
            sequence
                .Append(roydTextMeshPro.DOText(String.Empty, 0))
                .AppendCallback(() => { roydMouthAnimation.MouthAnimationStart(); })
                .Append(roydTextMeshPro.DOText(_messege, _messege.Length * _message_speed))
                .AppendCallback(() => { roydMouthAnimation.MouthAnimationStop(); })
                .AppendInterval(0.5f);

            // ソフィーカメラ有効
            sophieCamera.SetActive(true);

            // ソフィー顔ウインドウ表示
            sequence
                .Append(sophieFaceWindowCanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            // ソフィートークウインドウ表示
            sequence
                .Append(sophieTalkWindowCanvasGroup.DOFade(1f, 0.5f))
                .AppendInterval(0.5f);

            _messege = "了解、ロイド。まずは敵戦艦付近の偵察機と思わしき数体の機体の掃討をお願い。";
            sequence
                .Append(sophieTextMeshPro.DOText(String.Empty, 0))
                .AppendCallback(() => { sophieMouthAnimation.MouthAnimationStart(); })
                .Append(sophieTextMeshPro.DOText(_messege, _messege.Length * _message_speed))
                .AppendCallback(() => { sophieMouthAnimation.MouthAnimationStop(); })
                .AppendInterval(0.5f);

            _messege = "了解、これより攻撃を開始する。";
            sequence
                .Append(roydTextMeshPro.DOText(String.Empty, 0))
                .AppendCallback(() => { roydMouthAnimation.MouthAnimationStart(); })
                .Append(roydTextMeshPro.DOText(_messege, _messege.Length * _message_speed))
                .AppendCallback(() => { roydMouthAnimation.MouthAnimationStop(); })
                .AppendInterval(0.5f)
                .OnComplete(() => GameStart());

            sequence.Restart();
        }

        protected void GameStart()
        {
            // DOTweenシーケンスセット
            var sequence = DOTween
                .Sequence()
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            // トークウインドウ表示
            sequence
                .Append(roydTalkWindowCanvasGroup.DOFade(0f, 0.5f))
                .Join(sophieTalkWindowCanvasGroup.DOFade(0f, 0.5f))
                .AppendInterval(0.25f);

            // ロイド顔ウインドウ表示
            sequence
                .Append(roydFaceWindowCanvasGroup.DOFade(0f, 0.5f))
                .Join(sophieFaceWindowCanvasGroup.DOFade(0f, 0.5f))
                .AppendInterval(0.25f);

            // ソフィー顔ウインドウ表示
            sequence
                .Append(sophieFaceWindowCanvasGroup.DOFade(0f, 0.5f))
                .AppendInterval(0.25f);

            sequence
                .Append(missionWindowRectTransform.DOSizeDelta(
                    new Vector2(_initialMissionWindowSizeDelta.x, 2), 0.2f))
                .Append(missionWindowCanvasGroup.DOFade(0f, 0.5f))
                .Join(missionWindowRectTransform.DOSizeDelta(new Vector2(0, 2), 1f))
                .AppendInterval(0.5f)
                .OnComplete(() => SceneManager.LoadScene(gameScene));

            sequence.Restart();
        }
    }
}
