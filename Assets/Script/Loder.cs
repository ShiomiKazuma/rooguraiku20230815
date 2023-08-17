using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loder : MonoBehaviour
{
    public GameObject _gameManager;

    public void Awake()
    {
        if(GameManager._instance == null)
        {
            Instantiate(_gameManager);
        }
    }
}
