using UnityEngine;
using UnityEngine.Tilemaps;

public class FallTileGeneratorTester : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase groundTile;
    [SerializeField] private int holeWidth;
    [SerializeField] private int holeSize;
    [SerializeField] [Range(0f, 1f)] private float platformFrequency;
    [SerializeField] private int platformMinWidth;
    [SerializeField] private int platformMaxWidth;

    private void OnValidate()
    {
        var generator = new FallTileGenerator(tilemap, groundTile, holeWidth, holeSize, platformFrequency, platformMinWidth, platformMaxWidth);
        generator.GenerateTiles();
    }
}