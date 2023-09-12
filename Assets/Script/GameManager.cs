using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f;
    public static GameManager _instance;
    MapCreate _mapCreate;
    public static int _floor = 1;
    [SerializeField] int _level = 3;
    List<Enemy> _enemies;
    bool enemiesMoving;

    [SerializeField] int _maxFoodPoint = 100;
    public int _foodPoint = 100;
    [HideInInspector] public bool _playersTurn = true;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        _mapCreate = GetComponent<MapCreate>();
        InitGame();
        _foodPoint = _maxFoodPoint;
    }

    public void InitGame()
    {
        _mapCreate.SetUpScean(_level);
    }

    public void FoodRecover(int food)
    {
        _foodPoint += food;
        if(_foodPoint > _maxFoodPoint)
        {
            _foodPoint = _maxFoodPoint;
        }
    }

    public void GameOver()
    {
        enabled = false;
    }

}
