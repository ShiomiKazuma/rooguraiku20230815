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
    // Start is called before the first frame update
    void Start()
    {
        GameManager._level = 1;
        //スコアのロード
        _endresHighscore = PlayerPrefs.GetInt("EndresScore", 0);
        _mizeHighscore = PlayerPrefs.GetFloat("MizeScore", 0f);

        _endresScore.text = "EndressScore:" + _endresHighscore.ToString();
        _mizeScore.text = "MizeScore:" + _mizeHighscore.ToString();
        Debug.Log(GameManager._level);
    }

   
}
