﻿using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class FallTileGenerator
{
    private readonly Tilemap _tilemap;
    private readonly TileBase _groundTile;
    private readonly int _holeWidth;
    private readonly int _holeSize;
    private readonly int _platformFrequency;
    private readonly int _platformMinWidth;
    private readonly int _platformMaxWidth;
    
    private readonly Random _random;
    private int _lastPlacedPlatformIndex;

    public FallTileGenerator(Tilemap tilemap, TileBase groundTile, int holeWidth, int holeSize, float platformFrequency, int platformMinWidth, int platformMaxWidth)
    {
        _tilemap = tilemap;
        _groundTile = groundTile;
        _holeWidth = holeWidth;
        _holeSize = holeSize;
        _platformFrequency = (int) (platformFrequency * 100f);
        _platformMinWidth = platformMinWidth;
        _platformMaxWidth = platformMaxWidth;
        
        _random = new Random();
        _lastPlacedPlatformIndex = 0;
    }

    public void GenerateTiles()
    {
        _tilemap.ClearAllTiles();

        var halfWidth = _holeWidth / 2;

        for (var i = 0; i < _holeSize; i++)
        {
            _tilemap.SetTile(new Vector3Int(-halfWidth - 1, -i , 0), _groundTile);
            _tilemap.SetTile(new Vector3Int(halfWidth, -i , 0), _groundTile);

            for (var j = 0; j < 6; j++)
            {
                _tilemap.SetTile(new Vector3Int((-halfWidth - 1) - j, -i , 0), _groundTile);
                _tilemap.SetTile(new Vector3Int(halfWidth + j, -i, 0), _groundTile);
            }

            if (_lastPlacedPlatformIndex + 3 < i && _random.Next(0, 100) <= _platformFrequency)
            {
                _lastPlacedPlatformIndex = i;

                var platformWidth = _random.Next(_platformMinWidth, _platformMaxWidth);
                Debug.Log(platformWidth);
                var offsetX = _random.Next(-halfWidth, halfWidth);
                for (var x = -(platformWidth / 2) + offsetX; x <= platformWidth / 2 + offsetX; x++)
                {
                    _tilemap.SetTile(new Vector3Int(x, -i, 0), _groundTile);
                }
            }
        }
    }
}