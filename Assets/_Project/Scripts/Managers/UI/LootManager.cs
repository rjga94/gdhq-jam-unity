using System.Collections.Generic;
using TMPro;
using StateMachines.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class LootManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text lootText;
        [SerializeField] private PlayerController playerController;

        private void Update()
        {
            lootText.text = playerController.collectedShards.ToString();
        }
    }
}
