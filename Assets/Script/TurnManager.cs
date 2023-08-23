using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /// <summary>ターンの開始時に呼ばれるメソッド</summary>
    public static event Action OnBeginTurn;
    /// <summary>ターン終了時に呼ばれるメソッド</summary>
    public static event Action OnEndTurn;
    static bool _isTurnStarted = false;

    /// <summary>
    /// ターン開始時に呼ぶ
    /// </summary>
    public static void BeginTurn()
    {
        OnBeginTurn();
        _isTurnStarted = true;
    }

    /// <summary>
    /// ターン終了時に呼ぶ
    /// </summary>
    public static void EndTurn()
    {
        // ターンを開始せずに終了した場合はまず強制的にターンを開始する
        if (!_isTurnStarted)
        {
            BeginTurn();
        }
        OnEndTurn();
        _isTurnStarted = false;
    }
}
