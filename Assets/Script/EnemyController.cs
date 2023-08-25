using UnityEngine;

/// <summary>
/// �G�𐧌䂷��R���|�[�l���g
/// </summary>
//[RequireComponent(typeof(GridMoveController))]
public class EnemyController : TurnEventSubscriber
{
    /// <summary>���͈̔͂Ƀv���C���[������ꍇ�A�v���C���[�������邱�Ƃ��ł���</summary>
    [SerializeField] float m_playerSearchRangeRadius = 5f;
    /// <summary>�P�^�[���œ����̂ɂ����鎞�ԁi�P��: �b�j</summary>
    //[SerializeField] float m_moveTime = 1f;
    //GridMoveController m_gridMove = null;

    void Start()
    {
        //m_gridMove = GetComponent<GridMoveController>();
    }

    public override void OnBeginTurn()
    {
        //if (m_gridMove.IsMoving)
        //{
        //    m_gridMove.Skip();
        //}
    }

    public override void OnEndTurn()
    {
        // �ړ����������肷��
        GameObject player = SearchPlayer();
        int x = 0;
        int y = 0;

        if (player) // �v���C���[�����������ꍇ�͂��̕����Ɉړ�����
        {
            //�ׂ̃}�X�Ƀv���C���[������ꍇ�̏������L������

            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) > float.Epsilon)
            {
                x = player.transform.position.x > this.transform.position.x ? 1 : -1;
            }

            if (Mathf.Abs(player.transform.position.y - this.transform.position.y) > float.Epsilon)
            {
                y = player.transform.position.y > this.transform.position.y ? 1 : -1;
            }
        }
        else // �v���C���[��������Ȃ��ꍇ�̓����_���Ɉړ�����
        {
            x = Random.Range(-1, 2);
            y = Random.Range(-1, 2);
        }

        //m_gridMove.Move(x, y, m_moveTime);
    }

    /// <summary>
    /// ���G�͈͓�����v���C���[��������
    /// </summary>
    /// <returns>�v���C���[�����������炻�̃I�u�W�F�N�g��Ԃ��B������Ȃ��ꍇ�� null ��Ԃ��B</returns>
    GameObject SearchPlayer()
    {
        // �w��͈͂̃R���C�_�[��S�Ď擾����
        var cols = Physics2D.OverlapCircleAll(this.transform.position, m_playerSearchRangeRadius);

        // �v���C���[��T���ĕԂ�
        foreach (var c in cols)
        {
            if (c.gameObject.tag == "Player")
            {
                return c.gameObject;
            }
        }

        // ������Ȃ������� null ��Ԃ�
        return null;
    }
}
