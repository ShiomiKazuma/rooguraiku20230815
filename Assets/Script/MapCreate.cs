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
    public GameObject[] _foodTiles;
    public GameObject[] _outWallTiles;
    public GameObject[] _enemyTiles;
    public GameObject _Exit;
    public int _wallMin = 5;
    public int _wallMax = 9;
    public int _foodMin = 1;
    public int _foodMax = 5;

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
                    toInstansiate = _outWallTiles[Random.Range(0, _wallTiles.Length)];
                }
                else
                {
                    toInstansiate = _floorTiles[Random.Range(0, _floorTiles.Length)];
                }

                Instantiate(toInstansiate, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, _gridPositions.Count);

        Vector3 randomPosition = _gridPositions[randomIndex];
        _gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    private void LayoutObjectRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(0, max + 1);

        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetUpScean()
    {
        MapSetUp();
        InitialiseList();
        LayoutObjectRandom(_wallTiles, _wallMin, _wallMax);
        LayoutObjectRandom(_foodTiles, _foodMin, _foodMax);

        Instantiate(_Exit, new Vector3(_colums - 1, _rows - 1, 0), Quaternion.identity);
    }
}
