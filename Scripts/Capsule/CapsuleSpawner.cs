using System;
using Event.Signal;
using Status;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Capsule
{
    /// <summary>
    /// カプセル生成処理
    /// </summary>
    public class CapsuleSpawner : MonoBehaviour
    {
        [SerializeField] private GameStatus _gameStatus;

        /// <summary>
        /// 生成対象となるカプセル一式
        /// </summary>
        [SerializeField] private GameObject[] spawnCapsules;

        private void Start()
        {
            MessageBroker.Default.Receive<CapsuleSpawn>().Subscribe(x => CapsuleSpawn(x.CapsuleSpawnPoint)).AddTo(this);
        }

        /// <summary>
        /// カプセル生成処理
        /// </summary>
        /// <param name="capsuleSpawnTransform">カプセル生成箇所</param>
        private void CapsuleSpawn(Transform capsuleSpawnTransform)
        {
            // ランダムにカプセルを選択
            var capsuleObject = spawnCapsules[Random.Range(0, spawnCapsules.Length)];

            // 選択されたカプセルを生成
            var capsule = Instantiate(capsuleObject, capsuleSpawnTransform.position, Quaternion.identity);

            // 生成されたカプセルにゲームステータスを設定
            if (capsule.gameObject.TryGetComponent(out CapsuleMove capsuleMove))
            {
                capsuleMove.Initialize(_gameStatus.CurrentGameState);
            }
        }
    }
}
