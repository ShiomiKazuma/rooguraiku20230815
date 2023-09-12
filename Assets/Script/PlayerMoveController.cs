using UnityEngine;

/// <summary>
/// ターンベースでのプレイヤー移動を制御するコンポーネント
/// </summary>
//[RequireComponent(typeof(GridMoveController))]
public class PlayerMoveController : MonoBehaviour
{
    /// <summary>１ターンで動くのにかける時間（単位: 秒）</summary>
    [SerializeField] float _moveTime = 1f;
    GridMoveController m_gridMove = null;

    void Start()
    {
        m_gridMove = GetComponent<GridMoveController>();
    }

    void Update()
    {
        if (m_gridMove.IsMoving)    // 動いている最中は何もしない
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            // 移動可能ならば移動して、ターンを進める
            if (m_gridMove.Move((int)x, (int)y, _moveTime))
            {
                TurnManager.EndTurn();
            }
        }
    }
}
