using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TItleText : MonoBehaviour
{
    //対象テキスト
    [SerializeField] TMP_Text _text;
    //次の文字が出てくるまでの間隔
    [SerializeField] float _delayDuration = 0.1f;
    Coroutine _showCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        _showCoroutine = StartCoroutine(ShowCoroutine());
    }

    IEnumerator ShowCoroutine()
    {
        // GC Allocを最小化するためキャッシュしておく
        var delay = new WaitForSeconds(_delayDuration);

        // テキスト全体の長さ
        var length = _text.text.Length;

        // １文字ずつ表示する演出
        for (var i = 0; i < length; i++)
        {
            // 徐々に表示文字数を増やしていく
            _text.maxVisibleCharacters = i;

            // 一定時間待機
            yield return delay;
        }

        // 演出が終わったら全ての文字を表示する
        _text.maxVisibleCharacters = length;

        _showCoroutine = null;
    }
}
