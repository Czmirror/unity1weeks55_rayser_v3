using System;
using Event;
using Event.Signal;
using UniRx;
using UnityEngine;

namespace Score
{
    /// <summary>
    /// 敵機撃破時のスコア処理
    /// </summary>
    public class EnemyScore : MonoBehaviour
    {
        /// <summary>
        /// 加算スコア
        /// </summary>
        [SerializeField] private int score;

        public void ScoreAccumulation()
        {
            MessageBroker.Default.Publish(new ScoreAccumulation{Score = score});
        }

        private void OnDestroy()
        {
            ScoreAccumulation();
        }
    }
}
