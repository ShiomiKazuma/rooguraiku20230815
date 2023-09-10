using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField, Header("���肷��Ƃ��ɖ炷��")] AudioClip _select;
    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SelectSound()
    {
        _audioSource.PlayOneShot(_select);
    }

    /// <summary>
	/// �X���C�h�o�[�l�̕ύX�C�x���g
	/// </summary>
	/// <param name="newSliderValue">�X���C�h�o�[�̒l(�����I�Ɉ����ɒl������)</param>
	public void SoundSliderOnValueChange(float newSliderValue)
    {
        // ���y�̉��ʂ��X���C�h�o�[�̒l�ɕύX
        _audioSource.volume = newSliderValue;
    }
}
