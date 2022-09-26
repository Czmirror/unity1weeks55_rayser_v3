using Status;
using UniRx;
using UnityEngine;

namespace EnemyBreakdown
{
    /// <summary>
    /// ステージ中の敵機全滅処理
    /// </summary>
    public class StageEnemyBreakdown : MonoBehaviour
    {
        /// <summary>
        /// 全滅対象となるゲームステート
        /// </summary>
        [SerializeField] private GameState _gameState;

        private void Start()
        {
            MessageBroker.Default.Receive<Event.Signal.EnemyBreakdownSignal>()
                .Where(x => x.SettingGameState == _gameState).Subscribe(_ => BreakDown()).AddTo(this);
        }

        private void BreakDown()
        {
            Destroy(gameObject);
        }
    }
}
