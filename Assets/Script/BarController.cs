using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    /// <summary>ゲージを変化させる時間</summary>
    [SerializeField] float _changeInterval = 1f;
    /// <summary>HPバーを設定 </summary>
    [SerializeField] Slider _slider;

    public void Change(float value)
    {
        ChangeValue(_slider.value + value);
    }

    private void ChangeValue(float value)
    {
        DOTween.To(() => _slider.value, newValue => _slider.value = newValue,
       value, _changeInterval);      
    }
}
