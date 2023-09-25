using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;
using DG.Tweening;

public class GameClear : MonoBehaviour
{
    float _yourScore;
    float _highScore;
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _gameObject;
    [SerializeField] Image _panel;
    [SerializeField] AudioClip audioclip;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _gameObject.SetActive(false);
        _yourScore = float.Parse(PlayerMove2._time.ToString("F2"));
        _highScore = PlayerPrefs.GetFloat("MizeScore", 0f);
        _scoreText.text = "Your Score:" + _yourScore;
        if (_yourScore < _highScore || _highScore == 0f)
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
        audioSource.PlayOneShot(audioclip);
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 2.0f).OnComplete(() => SceneManager.LoadScene("Title"));
        //SceneManager.LoadScene("Title");
    }

}
