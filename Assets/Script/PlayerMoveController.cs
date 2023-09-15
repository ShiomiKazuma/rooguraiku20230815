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
    PlayerStatas _playerStatas;
    //移動する方向
    public ReactiveProperty<Vector2> _moveVec = new();
    float x;
    float y;
    bool _moving = false;
    bool _button = false;
    //音について
    public AudioClip _moveSound1;
    public AudioClip _moveSound2;
    void Start()
    {
        m_gridMove = GetComponent<GridMoveController>();
        _playerStatas = GetComponent<PlayerStatas>();
        //MoveTranstion();
    }

    void Update()
    {
        if (m_gridMove.IsMoving)    // 動いている最中は何もしない
        {
            return;
        }

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0 && !_moving)
        {
            // 移動可能ならば移動して、ターンを進める
            if (m_gridMove.Move((int)x, (int)y, _moveTime))
            {
                _moving = true;
                SoundManager.instance.RandomizeSfx(_moveSound1, _moveSound2);
                _playerStatas.FoodDes();
            }
        }
        if (!m_gridMove.IsMoving && _moving)
        {
            _moving = false;
            TurnManager.EndTurn();
        }
        //_moveVec.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //void MoveTranstion()
    //{
    //    _moveVec
    //        .Where(_ => !m_gridMove.IsMoving)
    //        .Subscribe(moveVec =>
    //        {
    //            if (moveVec.x != 0 || moveVec.y != 0 && !_moving)
    //            {
    //                // 移動可能ならば移動して、ターンを進める
    //                if (m_gridMove.Move((int)moveVec.x, (int)moveVec.y, _moveTime))
    //                {
    //                    _moving = true;
    //                    _playerStatas.FoodDes();
    //                }
    //            }

    //            if (!m_gridMove.IsMoving && _moving)
    //            {
    //                _moving = false;
    //                TurnManager.EndTurn();
    //            }
    //        }).AddTo(this);
    //}

    /// <summary>
    /// プレイヤーのターン終了時の処理を書く
    /// </summary>
    public virtual void OnEndTurn()
    {
        _playerStatas.CheckGameOver();
    }
}
