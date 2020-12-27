using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProceduralGeneration
{
    public class LevelGeneratorController : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private TileBase groundTile;
        [SerializeField] private int holeWidth;
        [SerializeField] private int holeSize;
    
        [SerializeField] [Range(0f, 1f)] private float platformFrequency;
        [SerializeField] private int platformMinWidth;
        [SerializeField] private int platformMaxWidth;

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] [Range(0f, 1f)] private float enemyFrequency;

        [SerializeField] private GameObject corePrefab;
    
        private void Awake()
        {
            var levelGenerator = new LevelGenerator(tilemap, groundTile, holeWidth, holeSize, platformFrequency, platformMinWidth, platformMaxWidth, corePrefab);
            levelGenerator.GenerateTiles();
        
            var enemyGenerator = new EnemyGenerator(levelGenerator, enemyPrefab, enemyFrequency);
            enemyGenerator.GenerateEnemies();
        }
    }
}