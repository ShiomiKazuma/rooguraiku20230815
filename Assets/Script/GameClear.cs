using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    float _yourScore;
    float _highScore;
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject.SetActive(false);
        _yourScore = PlayerMove2._time;
        _highScore = PlayerPrefs.GetFloat("MizeScore", 0f);
        _scoreText.text = "Your Score:" + _yourScore;
        if (_yourScore < _highScore)
        {
            _highScore = _yourScore;

            //"SCORE"���L�[�Ƃ��āA�n�C�X�R�A��ۑ�
            PlayerPrefs.SetFloat("MizeScore", _highScore);
            PlayerPrefs.Save();//�f�B�X�N�ւ̏�������
            _gameObject.SetActive(true);
            Debug.Log(_highScore);
            Debug.Log("�X�V");
        }
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

}
