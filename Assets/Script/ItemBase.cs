using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] ActiveTiming _timing = ActiveTiming.Get;
    public abstract void Activate();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_timing == ActiveTiming.Get)
        {
            Activate();
            Destroy(this.gameObject);
        }
        else if(_timing == ActiveTiming.Use)
        {
            //アイテムボックスに移動する処理
        }
    }
    enum ActiveTiming
    {
        Get,
        Use,
    }
}
