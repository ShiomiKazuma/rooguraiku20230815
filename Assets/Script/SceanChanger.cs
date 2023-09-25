using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceanChanger : MonoBehaviour
{
    [SerializeField] Image _panel;
    [SerializeField] AudioClip audioclip;
    [SerializeField] AudioSource audioSource;
    public void SceanChange()
    {
        _panel.gameObject.SetActive(true);
        audioSource.PlayOneShot(audioclip);
        _panel.DOFade(1, 3.0f).OnComplete(() => SceneManager.LoadScene("Endress"));
    }

    public void MizeSceanChange()
    {
        _panel.gameObject.SetActive(true);
        audioSource.PlayOneShot(audioclip);
        _panel.DOFade(1, 3.0f).OnComplete(() => SceneManager.LoadScene("Maze"));
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Title");
    }
}
