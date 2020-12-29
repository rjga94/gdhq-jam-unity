using System.Collections.Generic;
using Handlers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] private HealthHandler healthHandler;
        [SerializeField] private GameObject gridGO;
        [SerializeField] private GameObject heartPrefab;
        [SerializeField] private Sprite heartEmpty;

        private List<GameObject> _hearts;
        private float _startingHealth;

        private void Awake()
        {
            _hearts = new List<GameObject>();
            _startingHealth = healthHandler.Health;
            
            for (var i = 0; i < healthHandler.Health; i++)
            {
                _hearts.Add(Instantiate(heartPrefab, gridGO.transform));
            }
        }

        private void Start() => healthHandler.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged()
        {
            for (var i = _hearts.Count - 1; i >= healthHandler.Health; i--)
            {
                _hearts[i].GetComponent<Image>().sprite = heartEmpty;
            }
        }
    }
}