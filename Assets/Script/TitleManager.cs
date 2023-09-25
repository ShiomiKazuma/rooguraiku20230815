using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Text _endresScore;
    [SerializeField] Text _mizeScore;
    int _endresHighscore = 0;
    float _mizeHighscore = 0;
    [SerializeField] GameObject _delete;
    // Start is called before the first frame update
    void Start()
    {
        _delete.SetActive(false);
        GameManager._level = 1;
        //スコアのロード
        _endresHighscore = PlayerPrefs.GetInt("EndresScore", 0);
        _mizeHighscore = PlayerPrefs.GetFloat("MizeScore", 0f);

        _endresScore.text = "EndressScore:" + _endresHighscore.ToString();
        _mizeScore.text = "MizeScore:" + _mizeHighscore.ToString();
        Debug.Log(GameManager._level);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            _delete.SetActive(true);
        }
    }

}
