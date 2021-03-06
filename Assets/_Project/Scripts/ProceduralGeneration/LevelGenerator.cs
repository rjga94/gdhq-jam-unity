﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace ProceduralGeneration
{
    public class LevelGenerator
    {
        private readonly Tilemap _tilemap;
        private readonly TileSetSO _tileSet;
        private readonly int _holeWidth;
        private readonly int _holeSize;
        private readonly int _platformFrequency;
        private readonly int _platformMinWidth;
        private readonly int _platformMaxWidth;
        private readonly GameObject _corePrefab;
    
        private readonly Random _random;
        private int _lastPlacedPlatformIndex;

        public readonly List<List<Vector2Int>> PlatformPositions;

        public LevelGenerator(Tilemap tilemap, TileSetSO[] tileSets, int holeWidth, int holeSize, float platformFrequency, int platformMinWidth, int platformMaxWidth, GameObject corePrefab)
        {
            var random = new Random();
            
            _tilemap = tilemap;
            _tileSet = tileSets[random.Next(0, tileSets.Length)];
            _holeWidth = holeWidth;
            _holeSize = holeSize;
            _platformFrequency = (int) (platformFrequency * 100f);
            _platformMinWidth = platformMinWidth;
            _platformMaxWidth = platformMaxWidth;
            _corePrefab = corePrefab;
        
            _random = new Random();
            _lastPlacedPlatformIndex = 0;
            PlatformPositions = new List<List<Vector2Int>>();
        }

        private void UpdateTileSprites()
        {
            var bounds = _tilemap.cellBounds;
            for (var x = bounds.min.x; x < bounds.max.x; x++)
            {
                for (var y = bounds.min.y; y < bounds.max.y; y++)
                {
                    var tilePos = new Vector3Int(x, y, 0);
                    if (!_tilemap.HasTile(tilePos)) continue;

                    var newTile = _tileSet.centerTile;
                    if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y + 1, 0))) // top
                    {
                        if (!_tilemap.HasTile(new Vector3Int(tilePos.x - 1, tilePos.y, 0))) // left
                        {
                            newTile = _tileSet.topLeftTile;
                        }
                        else if (!_tilemap.HasTile(new Vector3Int(tilePos.x + 1, tilePos.y, 0))) // right
                        {
                            newTile = _tileSet.topRightTile;
                        }
                        else
                        {
                            newTile = _tileSet.topTile;   
                        }
                    } else if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y - 1, 0))) // bottom
                    {
                        if (!_tilemap.HasTile(new Vector3Int(tilePos.x - 1, tilePos.y, 0))) // left
                        {
                            newTile = _tileSet.bottomLeftTile;
                        }
                        else if (!_tilemap.HasTile(new Vector3Int(tilePos.x + 1, tilePos.y, 0))) // right
                        {
                            newTile = _tileSet.bottomRightTile;
                        }
                        else
                        {
                            newTile = _tileSet.bottomTile;
                        }
                    } else if (!_tilemap.HasTile(new Vector3Int(tilePos.x - 1, tilePos.y, 0))) // left
                    {
                        if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y + 1, 0))) // top
                        {
                            newTile = _tileSet.topLeftTile;
                        }
                        else if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y - 1, 0))) // bottom
                        {
                            newTile = _tileSet.bottomLeftTile;
                        }
                        else
                        {
                            newTile = _tileSet.leftTile;
                        }
                    } else if (!_tilemap.HasTile(new Vector3Int(tilePos.x + 1, tilePos.y, 0))) // right
                    {
                        if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y + 1, 0))) // top
                        {
                            newTile = _tileSet.topRightTile;
                        }
                        else if (!_tilemap.HasTile(new Vector3Int(tilePos.x, tilePos.y - 1, 0))) // bottom
                        {
                            newTile = _tileSet.bottomRightTile;
                        }
                        else
                        {
                            newTile = _tileSet.rightTile;
                        }
                    }
                    
                    
                    _tilemap.SetTile(new Vector3Int(x, y, 0), newTile);
                }
            }
        }

        public void GenerateTiles()
        {
            _tilemap.ClearAllTiles();

            var halfWidth = _holeWidth / 2;
        
            var key = 0;
            for (var i = 0; i < _holeSize; i++)
            {
                _tilemap.SetTile(new Vector3Int(-halfWidth - 1, -i , 0), _tileSet.centerTile);
                _tilemap.SetTile(new Vector3Int(halfWidth, -i , 0), _tileSet.centerTile);

                for (var j = 0; j < 18; j++)
                {
                    _tilemap.SetTile(new Vector3Int((-halfWidth - 1) - j, -i , 0), _tileSet.centerTile);
                    _tilemap.SetTile(new Vector3Int(halfWidth + j, -i, 0), _tileSet.centerTile);
                }

                if (_lastPlacedPlatformIndex + 3 < i && _random.Next(0, 100) <= _platformFrequency)
                {
                    _lastPlacedPlatformIndex = i;

                    var platformWidth = _random.Next(_platformMinWidth, _platformMaxWidth);
                    var offsetX = _random.Next(-halfWidth, halfWidth);
                    for (var x = -(platformWidth / 2) + offsetX; x <= platformWidth / 2 + offsetX; x++)
                    {
                        for (var j = 0; j < 4; j++)
                        {
                            _tilemap.SetTile(new Vector3Int(x, -i +j, 0), null);
                        }
                    
                        _tilemap.SetTile(new Vector3Int(x, -i, 0), _tileSet.centerTile);
                        if (key > PlatformPositions.Count - 1) PlatformPositions.Add(new List<Vector2Int>());
                        PlatformPositions[key].Add(new Vector2Int(x, -i));
                    }
                    key++;
                }
            }
        
            for (var j = _holeSize; j < _holeSize + 10; j++)
            {
                _tilemap.SetTile(new Vector3Int(-halfWidth - 1, -j , 0), _tileSet.centerTile);
                _tilemap.SetTile(new Vector3Int(halfWidth, -j , 0), _tileSet.centerTile);

                for (var k = 0; k < 18; k++)
                {
                    _tilemap.SetTile(new Vector3Int((-halfWidth - 1) - k, -j , 0), _tileSet.centerTile);
                    _tilemap.SetTile(new Vector3Int(halfWidth + k, -j, 0), _tileSet.centerTile);
                }

                for (var o = _holeSize + 10; o < _holeSize + 10 + 18; o++)
                {
                    for (var k = 0; k < 13 + _holeWidth; k++)
                    {
                        _tilemap.SetTile(new Vector3Int(-k - 1, -o , 0), _tileSet.centerTile);
                        _tilemap.SetTile(new Vector3Int(k, -o, 0), _tileSet.centerTile);
                    }
                }
            }

            UpdateTileSprites();
            
            foreach (var coreGO in GameObject.FindGameObjectsWithTag("Core")) Object.Destroy(coreGO);
            Object.Instantiate(_corePrefab, new Vector2(0, -(_holeSize + 5)), new Quaternion(0, 0, 0, 0));
        }
    }
}