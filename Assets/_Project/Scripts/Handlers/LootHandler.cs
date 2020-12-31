using System.Collections;
using Managers;
using StateMachines.Player;
using UnityEngine;

namespace Handlers
{
    [RequireComponent(typeof(Collider2D))]
    public class LootHandler : MonoBehaviour
    {
        [SerializeField] private GameObject parentGO;
        private SoundEffectsManager _soundEffectsManager;

        private static readonly System.Random random = new System.Random();

        private void Awake() => _soundEffectsManager = FindObjectOfType<SoundEffectsManager>();

        private void Start()
        {
            StartCoroutine(DestroySelfAfterTime());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<PlayerController>();
            if (player == null) return;

            player.collectedShards += 1;
            _soundEffectsManager.PlayPlayerPickup();
            Destroy(parentGO);
        }

        private IEnumerator DestroySelfAfterTime()
        {
            yield return new WaitForSeconds(random.Next(10, 15));
            Destroy(parentGO);
        }
    }
}