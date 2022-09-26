using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Event.Signal;
using Status;
using UnityEngine;

namespace Event
{
    using UniRx;

    /// <summary>
    /// 自機イベント移動用クラス
    /// </summary>
    public class EventPlayerMove : MonoBehaviour
    {
        /// <summary>
        /// Cinimacihne用メインカメラ
        /// </summary>
        [SerializeField] private GameObject MainCamera;

        /// <summary>
        /// Stage3用イベントカメラ（自機の背後に設置）
        /// </summary>
        [SerializeField] private GameObject Stage3EventCamera;

        /// <summary>
        /// バーチャルカメラ上部
        /// </summary>
        [SerializeField] private GameObject VirtualCameraTop;

        /// <summary>
        /// バーチャルカメラ上部（ステージ１ボス用）
        /// </summary>
        [SerializeField] private GameObject VirtualCameraTopStage1Boss;

        /// <summary>
        /// バーチャルカメラ側部
        /// </summary>
        [SerializeField] private GameObject VirtualCameraSide;

        /// <summary>
        /// バーチャルカメラ側部（ステージ２ボス用）
        /// </summary>
        [SerializeField] private GameObject VirtualCameraSideStage2Boss;

        /// <summary>
        /// バーチャルカメラ背後
        /// </summary>
        [SerializeField] private GameObject VirtualCameraBehind;

        /// <summary>
        /// ゲームステータス
        /// </summary>
        [SerializeField] private GameStatus _gameStatus;

        /// <summary>
        /// ゲーム開始時の自機の位置
        /// </summary>
        [SerializeField] private Vector3 gameStartPosition = new Vector3(1000, 100, 0);

        /// <summary>
        /// ゲーム開始時の自機の目標位置
        /// </summary>
        [SerializeField] private Vector3 gameStartPositionGoal = new Vector3(0, 100, 0);

        /// <summary>
        /// ステージ２開始時の自機の位置
        /// </summary>
        [SerializeField] private Vector3 stage2startPosition = new Vector3(-800, 0, 0);

        /// <summary>
        /// ゲーム開始地点までの移動時間
        /// </summary>
        [SerializeField] private float gameStartTime = 8f;

        /// <summary>
        /// ステージ２開始地点への移動時間
        /// </summary>
        [SerializeField] private float stage2MoveTime = 7f;

        /// <summary>
        /// ステージ３開始出発地点への移動時間
        /// </summary>
        [SerializeField] private float stage3StartMoveTime = 1f;

        /// <summary>
        /// ステージ３開始終着地点への移動時間
        /// </summary>
        [SerializeField] private float stage3GoalMoveTime = 8f;

        /// <summary>
        /// ステージ３開始終着地点への回転時間
        /// </summary>
        [SerializeField] private float stage3GoalRotateTime = 6f;

        /// <summary>
        /// ステージ２開始準備時間
        /// </summary>
        [SerializeField] private float stage2PreparationCameraTime = 2f;

        /// <summary>
        /// ステージ３開始準備時間
        /// </summary>
        [SerializeField] private float stage3PreparationCameraTime = 2f;

        /// <summary>
        /// ステージ３開始出発地点の座標
        /// </summary>
        [SerializeField] private Vector3 stage3StartPosition = new Vector3(-1200, 0, 0);

        /// <summary>
        /// ステージ３開始終着地点の座標
        /// </summary>
        [SerializeField] private Vector3 stage3GoalPosition = new Vector3(-1000, 50, -100);

        /// <summary>
        /// ステージ３開始終着地点の回転軸
        /// </summary>
        [SerializeField] private Vector3 stage3GorlRotation = new Vector3(-0, -180, 0);

        private void Start()
        {
            _gameStatus.CurrentGameStateReactiveProperty
                .Where(x =>
                    x == GameState.Gamestart
                )
                .Subscribe(_ => GameStartMove())
                .AddTo(this);

            _gameStatus.CurrentGameStateReactiveProperty
                .Where(x =>
                    x == GameState.Stage1Boss
                )
                .Subscribe(_ => Stage1Boss())
                .AddTo(this);

            _gameStatus.CurrentGameStateReactiveProperty
                .Where(x =>
                    x == GameState.Stage2Interval
                )
                .Subscribe(_ => Stage2IntervalEventStart(this.GetCancellationTokenOnDestroy()))
                .AddTo(this);

            _gameStatus.CurrentGameStateReactiveProperty
                .Where(x =>
                    x == GameState.Stage2Boss
                )
                .Subscribe(_ => Stage2Boss())
                .AddTo(this);

            _gameStatus.CurrentGameStateReactiveProperty
                .Where(x =>
                    x == GameState.Stage3Interval
                )
                .Subscribe(_ => Stage3IntervalEventStart(this.GetCancellationTokenOnDestroy()))
                .AddTo(this);
        }

        /// <summary>
        /// ゲーム開始時
        /// </summary>
        private void GameStartMove()
        {
            gameObject.transform.position = gameStartPosition;
            VirtualCameraTop.SetActive(false);
            VirtualCameraTopStage1Boss.SetActive(false);
            VirtualCameraSide.SetActive(false);
            VirtualCameraSideStage2Boss.SetActive(false);
            transform.DOMove(gameStartPositionGoal, gameStartTime)
                .OnComplete(() => GameStartEventEnd())
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject)
                .Restart();
        }

        private void GameStartEventEnd()
        {
            VirtualCameraTop.SetActive(true);
            MessageBroker.Default.Publish(new GameStartEventEnd { EventEnd = true });
        }

        private void Stage1Boss()
        {
            VirtualCameraTop.SetActive(false);
            VirtualCameraTopStage1Boss.SetActive(true);
        }

        private async UniTaskVoid Stage2IntervalEventStart(CancellationToken cancellationToken)
        {
            // イベント移動前に自機の向きを進行方向に補正
            var direction = new Vector3(0, 0, 1);
            transform.localRotation = Quaternion.LookRotation(direction);

            VirtualCameraTop.SetActive(false);
            VirtualCameraTopStage1Boss.SetActive(false);

            await UniTask.Delay(TimeSpan.FromSeconds(stage3PreparationCameraTime), false, 0, cancellationToken);

            transform.DOMove(stage2startPosition, stage2MoveTime)
                .OnComplete(() => Stage2IntervalEventEnd())
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject)
                .Restart();
        }

        private void Stage2IntervalEventEnd()
        {
            VirtualCameraSide.SetActive(true);
            MessageBroker.Default.Publish(new Stage2Start());
        }

        private void Stage2Boss()
        {
            VirtualCameraSide.SetActive(false);
            VirtualCameraSideStage2Boss.SetActive(true);
        }

        private async UniTaskVoid Stage3IntervalEventStart(CancellationToken cancellationToken)
        {
            VirtualCameraSide.SetActive(false);
            VirtualCameraSideStage2Boss.SetActive(false);

            // バーチャルカメラからイベントカメラに切り返す前のインターバル
            await UniTask.Delay(TimeSpan.FromSeconds(stage3PreparationCameraTime), false, 0, cancellationToken);
            MainCamera.SetActive(false);
            Stage3EventCamera.SetActive(true);

            // DOTweenシーケンスセット
            var sequence = DOTween.Sequence();

            sequence
                .Append(transform.DOMove(stage3StartPosition, stage3StartMoveTime))
                .Append(transform.DOMove(stage3GoalPosition, stage3GoalMoveTime))
                .Join(transform.DORotate(stage3GorlRotation, stage3GoalRotateTime))
                .OnComplete(() => { Stage3IntervalEventEnd(); })
                .Pause()
                .SetAutoKill(false)
                .SetLink(gameObject);

            sequence.Restart();
        }

        private void Stage3IntervalEventEnd()
        {
            VirtualCameraTop.SetActive(false);
            VirtualCameraSide.SetActive(false);

            // 背後のバーチャルカメラに背後イベントカメラの位置情報を付与（バーチャルカメラが自機の真正面になってしまうのを防ぐため）
            VirtualCameraBehind.transform.position = Stage3EventCamera.transform.position;
            VirtualCameraBehind.transform.rotation = Stage3EventCamera.transform.rotation;

            // イベントカメラをCinemachineのバーチャルカメラに戻す
            MainCamera.SetActive(true);
            Stage3EventCamera.SetActive(false);

            MessageBroker.Default.Publish(new Stage3Start());
        }
    }
}
