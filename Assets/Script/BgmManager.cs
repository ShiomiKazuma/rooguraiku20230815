using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BgmManager : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得
        _audioSource = GetComponent<AudioSource>();
        //オーディオクリップを設定
        _audioSource.clip = _clip;
        _audioSource.playOnAwake = true;
        _audioSource.loop = true;
    }

    /// <summary>
	/// スライドバー値の変更イベント
	/// </summary>
	/// <param name="newSliderValue">スライドバーの値(自動的に引数に値が入る)</param>
	public void SoundSliderOnValueChange(float newSliderValue)
    {
        // 音楽の音量をスライドバーの値に変更
        _audioSource.volume = newSliderValue;
    }
}
