using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProceduralGeneration
{
    [CreateAssetMenu(fileName = "TileSet", menuName = "Game/Tile Set", order = 0)]
    public class TileSetSO : ScriptableObject
    {
        public TileBase topLeftTile,
            topTile,
            topRightTile,
            leftTile,
            centerTile,
            rightTile,
            bottomLeftTile,
            bottomTile,
            bottomRightTile;
    }
}