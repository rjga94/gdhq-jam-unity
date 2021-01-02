using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectsManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _playerJumpSamples, _playerAttackSamples, _playerPickupSamples;

        private AudioSource _audioSource;
        
        private void Awake() => _audioSource = GetComponent<AudioSource>();

        public void PlayPlayerJump()
        {
            var random = new System.Random((int)Time.time);
            _audioSource.clip = _playerJumpSamples[random.Next(0, _playerJumpSamples.Length)];
            _audioSource.Play();
        }

        public void PlayPlayerAttack()
        {
            var random = new System.Random((int)Time.time);
            _audioSource.clip = _playerAttackSamples[random.Next(0, _playerAttackSamples.Length)];
            _audioSource.Play();
        }

        public void PlayPlayerPickup()
        {
            var random = new System.Random((int)Time.time);
            _audioSource.clip = _playerPickupSamples[random.Next(0, _playerPickupSamples.Length)];
            _audioSource.Play();
        }
    }
}