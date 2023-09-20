using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TItleText : MonoBehaviour
{
    //�Ώۃe�L�X�g
    [SerializeField] TMP_Text _text;
    //���̕������o�Ă���܂ł̊Ԋu
    [SerializeField] float _delayDuration = 0.1f;
    Coroutine _showCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    IEnumerator ShowCoroutine()
    {
        // GC Alloc���ŏ������邽�߃L���b�V�����Ă���
        var delay = new WaitForSeconds(_delayDuration);

        // �e�L�X�g�S�̂̒���
        var length = _text.text.Length;

        // �P�������\�����鉉�o
        for (var i = 0; i < length; i++)
        {
            // ���X�ɕ\���������𑝂₵�Ă���
            _text.maxVisibleCharacters = i;

            // ��莞�ԑҋ@
            yield return delay;
        }

        // ���o���I�������S�Ă̕�����\������
        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }
}
