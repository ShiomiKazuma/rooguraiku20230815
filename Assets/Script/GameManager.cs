using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public float turnDelay = 0.1f;
    public static GameManager _instance;
    MapCreate _mapCreate;
    public static int _floor = 1;
    public static int _level = 3;
    List<Enemy> _enemies;
    bool enemiesMoving;

    [SerializeField] int _maxFoodPoint = 100;
    public int _foodPoint = 100;
    [HideInInspector] public bool _playersTurn = true;

    Text _levelText;
    GameObject _levelImage;
    bool doingSetup;

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
        //_enemies = new List<Enemy>();
        _mapCreate = GetComponent<MapCreate>();
        InitGame();
        _foodPoint = _maxFoodPoint;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    public void InitGame()
    {
        //ロード中の背景を表示
        doingSetup = true;
        _levelImage = GameObject.Find("LevelImage");
        _levelText = GameObject.Find("LevelText").GetComponent<Text>();
        _levelText.text = "Day" + _level;
        _levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        //_enemies.Clear();
        //マップの生成
        _mapCreate.SetUpScean(_level);
    }

    void HideLevelImage()
    {
        _levelImage.SetActive(false);
        doingSetup = false;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        _level++;
        InitGame();
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
        _levelText.text = "After" + _level + "days, you starved.";
        _levelImage.SetActive(true);
        enabled = false;
    }

    private void Update()
    {
        //if(_playersTurn || enemiesMoving)
        //{
        //    return;
        //}

        //StartCoroutine(MoveEnemies());

    }

    //public void AddEnemyToList(Enemy script)
    //{
    //    _enemies.Add(script);
    //}
    //IEnumerator MoveEnemies()
    //{
    //    enemiesMoving = true;
    //    yield return new WaitForSeconds(turnDelay);
    //    if(_enemies.Count == 0)
    //    {
    //        yield return new WaitForSeconds(turnDelay);
    //    }

    //    for (int i = 0; i < _enemies.Count; i++)
    //    {
    //        _enemies[i].MoveEnemy();
    //        yield return new WaitForSeconds(_enemies[i].moveTime);
    //    }

    //    _playersTurn = true;
    //    enemiesMoving = false;
    //}
}
