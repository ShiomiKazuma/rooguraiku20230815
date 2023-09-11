using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    MapCreate _mapCreate;
    public static int _floor = 1;
    [SerializeField] int _level = 3;
    [SerializeField] int _maxFoodPoint = 100;
    public int _foodPoint = default;

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
    }

    public void InitGame()
    {
        _mapCreate.SetUpScean(_level);
    }
    // Start is called before the first frame update
    void Start()
    {
        _foodPoint = _maxFoodPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoodRecover(int food)
    {
        _foodPoint += food;
        if(_foodPoint > _maxFoodPoint)
        {
            _foodPoint = _maxFoodPoint;
        }
    }

}
