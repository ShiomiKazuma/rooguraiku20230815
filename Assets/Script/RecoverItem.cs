using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecoverItem : ItemBase
{
    [SerializeField] int _recoverNum = 5;
    [SerializeField] PlayerStatas _playerStatas;
    public override void Activate()
    {
        if (_playerStatas._hp < _playerStatas._maxHp)
        {
            _playerStatas._hp += _recoverNum;
            //マックスより上ならマックスにする
            if(_playerStatas._hp > _playerStatas._maxHp)
            {
                _playerStatas._hp = _playerStatas._maxHp;
            }
        }
    }

}
