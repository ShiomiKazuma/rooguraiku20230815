using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    /// <summary>動けるマップ範囲</summary>
    [SerializeField] public int _colums = 8, _rows = 8;
    /// <summary>ランダム生成するための座標</summary>
    List<Vector3> _gridPositions = new List<Vector3>();
    public GameObject[] _floorTiles;
    public GameObject[] _wallTiles;
    public GameObject[] _foodtiles;
    public GameObject[] _outWalltiles;
    public GameObject[] _enemytiles;


    void InitialiseList()
    {
        _gridPositions.Clear();

        for(int x = 1; x < _colums - 1; x++)
        {
            for(int  y = 1; y < _rows - 1; y++)
            {
                _gridPositions.Add(new Vector3(x, y, 0));
            }
        }
    }

    private void MapSetUp()
    {
        for(int x = -1; x < _colums + 1; x++)
        {
            for(int y = -1;  y < _rows + 1; y++)
            {
                GameObject toInstansiate;
                
                if(x == 1 || x == _colums || y == -1 || y == _rows)
                {
                    toInstansiate = _outWalltiles[Random.Range(0, _wallTiles.Length)];
                }
                else
                {
                    toInstansiate = _floorTiles[Random.Range(0, _floorTiles.Length)];
                }
            }
        }
    }
}
