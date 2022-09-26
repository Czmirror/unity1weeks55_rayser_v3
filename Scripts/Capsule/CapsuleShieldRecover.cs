using Event.Signal;
using Status;
using UniRx;
using UnityEngine;
namespace Capsule
{
    /// <summary>
    /// シールドリカバーカプセル処理
    /// </summary>
    public class CapsuleShieldRecover : MonoBehaviour, ICapsuleinfo
    {
        [SerializeField] private CapsuleEnum capsuleEnum = CapsuleEnum.ShieldRecover;
        [SerializeField] private float shieldRecoverPoint = 20;

        [SerializeField] private AudioSource _audioSource;

        /// <summary>
        /// カプセル取得時のサウンド
        /// </summary>
        [SerializeField] private AudioClip capsuleRecoverySound;

        /// <summary>
        /// カプセル発動時のサウンド
        /// </summary>
        [SerializeField] private AudioClip capsuleEffectActivatedSound;
        public void CapsuleRecovery()
        {
            // _audioSource.clip = capsuleRecoverySound;
            // _audioSource.Play();
            MessageBroker.Default.Publish(new PlayerGetCapsule(this));
            Destroy(gameObject);
        }

        public void CapsuleEffectActivated()
        {
            // _audioSource.clip = capsuleEffectActivatedSound;
            // _audioSource.Play();
            MessageBroker.Default.Publish(new PlayerShieldRecover(shieldRecoverPoint));
        }

        public CapsuleEnum GetCapsuleEnum()
        {
            return capsuleEnum;
        }

    }
}
