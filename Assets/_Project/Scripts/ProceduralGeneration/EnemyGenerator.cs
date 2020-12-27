using UnityEngine;

namespace ProceduralGeneration
{
    public class EnemyGenerator
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly GameObject _enemyPrefab;
        private readonly int _enemyFrequency;

        private readonly System.Random _random;
    
        public EnemyGenerator(LevelGenerator levelGenerator, GameObject enemyPrefab, float enemyFrequency)
        {
            _levelGenerator = levelGenerator;
            _enemyPrefab = enemyPrefab;
            _enemyFrequency = (int) (enemyFrequency * 100f);
        
            _random = new System.Random();
        }

        public void GenerateEnemies()
        {
            foreach (var enemyGO in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Object.Destroy(enemyGO);
            }

            foreach (var platformPos in _levelGenerator.PlatformPositions)
            {
                if (_random.Next(0, 100) <= _enemyFrequency)
                {
                    var pos = platformPos[_random.Next(platformPos.Count - 1)];
                    Object.Instantiate(_enemyPrefab, new Vector3(pos.x + 1, pos.y + 2), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}