using System;
using StateMachines.Player;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class PlayerLevelManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private TMP_Text _totalShards;
        [SerializeField] private TMP_Text _upgradeCost;
        [SerializeField] private TMP_Text _attackRateText, _movementSpeedText;

        private int _levelCounter = 1, _attackRateLevel = 1, _movementSpeedLevel = 1;
        private const int shardCostMultiplier = 10;
        private int _currentUpgradeCost = shardCostMultiplier;

        private void Start()
        {
            IncreaseUpgradeCost();
        }

        private void Update()
        {
            _totalShards.text = _playerController.collectedShards.ToString();

            if (_attackRateLevel == 5) _attackRateText.text = "Max";
            else _attackRateText.text = _attackRateLevel.ToString();

            if (_movementSpeedLevel == 5) _movementSpeedText.text = "Max";
            else _movementSpeedText.text = _movementSpeedLevel.ToString();

            if (_attackRateLevel == 5 && _movementSpeedLevel == 5) _upgradeCost.text = "";
            else _upgradeCost.text = $"Upgrade cost: {_currentUpgradeCost}";
        }
        
        public void OnIncreaseAttackRateButtonClick()
        {
            if (_attackRateLevel == 5) return;
            if (_playerController.collectedShards >= _currentUpgradeCost)
            {
                _playerController.collectedShards -= _currentUpgradeCost;
                _playerController.fireRate -= 0.1f;
                _levelCounter += 1;
                _attackRateLevel += 1;
                IncreaseUpgradeCost();
            }
        }

        public void OnIncreaseMovementSpeedButtonClick()
        {
            if (_movementSpeedLevel == 5) return;
            if (_playerController.collectedShards >= _currentUpgradeCost)
            {
                _playerController.collectedShards -= _currentUpgradeCost;
                _playerController.movementSpeed += 1;
                _levelCounter += 1;
                _movementSpeedLevel += 1;
                IncreaseUpgradeCost();
            }
        }

        private void IncreaseUpgradeCost() => _currentUpgradeCost = shardCostMultiplier * _levelCounter;
    }
}