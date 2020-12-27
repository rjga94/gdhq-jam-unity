using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallTileGeneratorTester : MonoBehaviour
{
    private LevelGenerator _levelGenerator;
    
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase groundTile;
    [SerializeField] private int holeWidth;
    [SerializeField] private int holeSize;
    
    [SerializeField] [Range(0f, 1f)] private float platformFrequency;
    [SerializeField] private int platformMinWidth;
    [SerializeField] private int platformMaxWidth;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(0f, 1f)] private float enemyFrequency;

    private void OnValidate()
    {
        _levelGenerator = new LevelGenerator(tilemap, groundTile, holeWidth, holeSize, platformFrequency, platformMinWidth, platformMaxWidth);
        _levelGenerator.GenerateTiles();
    }

    private void Awake()
    {
        var enemyGenerator = new EnemyGenerator(_levelGenerator, enemyPrefab, enemyFrequency);
        enemyGenerator.GenerateEnemies();
    }
}