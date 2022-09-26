using System;
using UnityEngine;

namespace Turret
{
    using UniRx;
    using UniRx.Triggers;

    public class EnemyBeamTurret : MonoBehaviour
    {
        /// <summary>
        /// ショットの自動消滅時間
        /// </summary>
        [SerializeField] private float shotInterbalTime = 1.5f;

        /// <summary>
        /// 敵機のビームのゲームオブジェクト
        /// </summary>
        [SerializeField] private GameObject enemyBeam;

        private void Start()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(shotInterbalTime))
                .Subscribe(_ => { EnemyShot(); }).AddTo(this);
        }


        private void EnemyShot()
        {
            GameObject _shot = Instantiate(enemyBeam, transform.position, transform.rotation);
        }
    }
}
