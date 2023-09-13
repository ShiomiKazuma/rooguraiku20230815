using UnityEngine;
using UniRx;

/// <summary>
/// �^�[���x�[�X�ł̃v���C���[�ړ��𐧌䂷��R���|�[�l���g
/// </summary>
//[RequireComponent(typeof(GridMoveController))]
public class PlayerMoveController : MonoBehaviour
{
    /// <summary>�P�^�[���œ����̂ɂ����鎞�ԁi�P��: �b�j</summary>
    [SerializeField] float _moveTime = 1f;
    GridMoveController m_gridMove = null;
    //�ړ��������
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
        //if (m_gridMove.IsMoving)    // �����Ă���Œ��͉������Ȃ�
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
                    // �ړ��\�Ȃ�Έړ����āA�^�[����i�߂�
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
    /// �v���C���[�̃^�[���I�����̏���������
    /// </summary>
    public virtual void OnEndTurn()
    {
        
    }
}
