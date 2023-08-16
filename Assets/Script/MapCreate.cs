using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    /// <summary>������}�b�v�͈�</summary>
    [SerializeField] public int _colums = 8, _rows = 8;
    /// <summary>�����_���������邽�߂̍��W</summary>
    List<Vector3> _gridPositions = new List<Vector3>();
    public GameObject[] _floorTiles;
    public GameObject[] _wallTiles;
    public GameObject[] _foodtiles;
    public GameObject[] _outWalltiles;
    public GameObject[] _enemytiles;

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
                    toInstansiate = _outWalltiles[Random.Range(0, _wallTiles.Length)];
                }
                else
                {
                    toInstansiate = _floorTiles[Random.Range(0, _floorTiles.Length)];
                }
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
}
