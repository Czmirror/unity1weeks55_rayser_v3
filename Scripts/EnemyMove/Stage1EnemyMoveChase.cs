using Target;
using UnityEngine;

namespace EnemyMove
{
    /// <summary>
    /// ステージ１敵機追跡処理
    /// </summary>
    public class Stage1EnemyMoveChase : MonoBehaviour
    {
        [SerializeField] private EnemyTarget _enemyTarget;
        [SerializeField] private float moveSpeed = 0.08f;

        /// <summary>
        /// ターゲットへの接近可能距離
        /// </summary>
        private float stopDistance = 10f;

        void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(_enemyTarget.CurrentTarget().transform.position - transform.position), 0.3f);

            var distance = Vector3.Distance(transform.position, _enemyTarget.CurrentTarget().transform.position);

            if (distance < stopDistance)
            {
                 return;
            }

            transform.position += transform.forward * moveSpeed;
        }
    }
}
