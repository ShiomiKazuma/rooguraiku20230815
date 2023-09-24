using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public float turnDelay = 0.1f;
    public static GameManager _instance;
    MapCreate _mapCreate;
    public static int _floor = 1;
    public static int _level = 1;
    List<Enemy> _enemies;
    bool enemiesMoving;

    [SerializeField] int _maxFoodPoint = 100;
    public int _foodPoint = 100;
    [HideInInspector] public bool _playersTurn = true;

    Text _levelText;
    GameObject _levelImage;
    bool doingSetup;
    int _highScore;
    GameObject _titleButton;
    GameObject _soundManager;
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
        _soundManager = GameObject.Find("SoundManager");
        //Cursor.lockState = LockMode.Locked;
        //Cursor.visible = false;
    }
    public void InitGame()
    {
        //ロード中の背景を表示
        doingSetup = true;
        _levelImage = GameObject.Find("LevelImage");
        _levelText = GameObject.Find("LevelText").GetComponent<Text>();
        _levelText.text =  _level + " floor dungeon";
        _levelImage.SetActive(true);
        _titleButton = GameObject.Find("Title");
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
        SceneManager.sceneLoaded -= SceneLoaded;
        Scene sampleScene1 = SceneManager.GetSceneByName("Endress");
        SceneManager.MoveGameObjectToScene(this.gameObject, sampleScene1);
        SceneManager.MoveGameObjectToScene(_soundManager, sampleScene1);
        SceneManager.LoadScene("GameOver");
        
        //_levelText.text = _level + " floor dungeon breakthrough";
        //_highScore = PlayerPrefs.GetInt("EndresScore", 0);
        //if (_level > _highScore)
        //{
        //    _highScore = _level;

        //    //"SCORE"をキーとして、ハイスコアを保存
        //    PlayerPrefs.SetInt("EndresScore", _highScore);
        //    PlayerPrefs.Save();//ディスクへの書き込み
        //    //_gameObject.SetActive(true);
        //}
        //_levelImage.SetActive(true);
        //_titleButton.SetActive(true);
        //enabled = false;
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
