using UnityEngine;
using UniRx;

/// <summary>
/// ターンベースでのプレイヤー移動を制御するコンポーネント
/// </summary>
//[RequireComponent(typeof(GridMoveController))]
public class PlayerMoveController : MonoBehaviour
{
    /// <summary>１ターンで動くのにかける時間（単位: 秒）</summary>
    [SerializeField] float _moveTime = 1f;
    GridMoveController m_gridMove = null;
    //移動する方向
    public ReactiveProperty<Vector2> _moveVec = new();
    float x;
    float y;
    bool _moving = false;
    bool _button = false;
    void Start()
    {
        m_gridMove = GetComponent<GridMoveController>();
        MoveTranstion();
    }

    void Update()
    {
        //if (m_gridMove.IsMoving)    // 動いている最中は何もしない
        //{
        //    return;
        //}

        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");

        //if (!m_gridMove.IsMoving && _moving)
        //{
        //    _moving = false;
        //    TurnManager.EndTurn();
        //}
        _moveVec.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void MoveTranstion()
    {
        _moveVec
            .Where(_ => !m_gridMove.IsMoving)
            .Subscribe(moveVec =>
            {
                if (moveVec.x != 0 || moveVec.y != 0 && !_moving)
                {
                    // 移動可能ならば移動して、ターンを進める
                    if (m_gridMove.Move((int)moveVec.x, (int)moveVec.y, _moveTime))
                    {
                        _moving = true;
                    }
                }

                if (!m_gridMove.IsMoving && _moving)
                {
                    _moving = false;
                    TurnManager.EndTurn();
                }
            }).AddTo(this);
    }

    /// <summary>
    /// プレイヤーのターン終了時の処理を書く
    /// </summary>
    public virtual void OnEndTurn()
    {
        
    }
}
