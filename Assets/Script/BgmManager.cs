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
        //AudioSource�R���|�[�l���g���擾
        _audioSource = GetComponent<AudioSource>();
        //�I�[�f�B�I�N���b�v��ݒ�
        _audioSource.clip = _clip;
        _audioSource.playOnAwake = true;
        _audioSource.loop = true;
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
