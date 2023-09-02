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
            //�A�C�e���{�b�N�X�Ɉړ����鏈��
        }
    }
    enum ActiveTiming
    {
        Get,
        Use,
    }
}
