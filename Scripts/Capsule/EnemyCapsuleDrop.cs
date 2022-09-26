using System;
using Event.Signal;
using UniRx;
using UnityEngine;

namespace Capsule
{
    /// <summary>
    /// 敵機カプセルドロップ処理
    /// </summary>
    public class EnemyCapsuleDrop : MonoBehaviour
    {
        private void OnDestroy()
        {
            MessageBroker.Default.Publish(new CapsuleSpawn(transform));
        }
    }
}
