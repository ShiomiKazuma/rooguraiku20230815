using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /// <summary>�^�[���̊J�n���ɌĂ΂�郁�\�b�h</summary>
    public static event Action OnBeginTurn;
    /// <summary>�^�[���I�����ɌĂ΂�郁�\�b�h</summary>
    public static event Action OnEndTurn;
    static bool _isTurnStarted = false;

    /// <summary>
    /// �^�[���J�n���ɌĂ�
    /// </summary>
    public static void BeginTurn()
    {
        OnBeginTurn();
        _isTurnStarted = true;
    }

    /// <summary>
    /// �^�[���I�����ɌĂ�
    /// </summary>
    public static void EndTurn()
    {
        // �^�[�����J�n�����ɏI�������ꍇ�͂܂������I�Ƀ^�[�����J�n����
        if (!_isTurnStarted)
        {
            BeginTurn();
        }
        OnEndTurn();
        _isTurnStarted = false;
    }
}
