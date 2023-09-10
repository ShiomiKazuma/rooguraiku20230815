using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    MapCreate _mapCreate;
    public static int _floor = 1;
    [SerializeField] int level = 3;

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
        _mapCreate.SetUpScean(level);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
