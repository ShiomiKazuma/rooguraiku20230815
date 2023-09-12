using UnityEngine;

/// <summary>
/// �^�[���x�[�X�ł̃v���C���[�ړ��𐧌䂷��R���|�[�l���g
/// </summary>
//[RequireComponent(typeof(GridMoveController))]
public class PlayerMoveController : MonoBehaviour
{
    /// <summary>�P�^�[���œ����̂ɂ����鎞�ԁi�P��: �b�j</summary>
    [SerializeField] float _moveTime = 1f;
    GridMoveController m_gridMove = null;

    void Start()
    {
        m_gridMove = GetComponent<GridMoveController>();
    }

    void Update()
    {
        if (m_gridMove.IsMoving)    // �����Ă���Œ��͉������Ȃ�
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            // �ړ��\�Ȃ�Έړ����āA�^�[����i�߂�
            if (m_gridMove.Move((int)x, (int)y, _moveTime))
            {
                TurnManager.EndTurn();
            }
        }
    }
}
