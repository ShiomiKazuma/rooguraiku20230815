using System.Collections;
using UnityEngine;

/// <summary>
/// �O���b�h�ړ��𐧌䂷��R���|�[�l���g�B�ړ������鎞�� Move �֐����g���B
/// </summary>
public class GridMoveController : MonoBehaviour
{
    /// <summary>�ړ���W�Q����R���C�_�[���������郌�C���[���w�肷��</summary>
    [SerializeField] LayerMask m_walkableLayerMask;
    /// <summary>�ړ����t���O</summary>
    bool m_isMoving = false;
    /// <summary>Move �Ŏw�肳�ꂽ�ړI�n��ۑ�����</summary>
    Vector2Int m_destination;

    /// <summary>
    /// �I�u�W�F�N�g���ړ����Ȃ�� true, �����łȂ��ꍇ�� false ��Ԃ�
    /// </summary>
    public bool IsMoving
    {
        get { return m_isMoving; }
    }

    /// <summary>
    /// �w�肳�ꂽ���΍��W�Ɋ��炩�Ɉړ�����B�w�肳�ꂽ���W�Ɉړ��ł��Ȃ��ꍇ�͉������Ȃ��B
    /// </summary>
    /// <param name="x">�ړ����� X ���W</param>
    /// <param name="y">�ړ����� Y ���W</param>
    /// <param name="moveTime">���b�����Ĉړ����邩</param>
    /// <returns>�ړ��\�ȏꍇ�� true, �ړ��ł��Ȃ��ꍇ�� false</returns>
    public bool Move(int x, int y, float moveTime)
    {
        m_isMoving = false;

        // �w�肳�ꂽ�����Ɉړ��ł��邩�ǂ������肷��
        Vector2 destination = (Vector2)this.transform.position + new Vector2(x, y);
        var col = Physics2D.OverlapCircle(destination, .1f, m_walkableLayerMask);

        if (col == null)    // �ړ��\
        {
            m_isMoving = true;
            StartCoroutine(MoveRoutine(x, y, moveTime));
        }

        return m_isMoving;
    }

    /// <summary>
    /// �w�肳�ꂽ���΍��W�Ɋ��炩�Ɉړ�����
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="moveTime"></param>
    /// <returns></returns>
    IEnumerator MoveRoutine(int x, int y, float moveTime)
    {
        // �ړ�����v�Z����
        Vector2Int origin = Vector2Int.RoundToInt(this.transform.position);
        m_destination = origin + new Vector2Int(x, y);

        while (Vector2.Distance(this.transform.position, m_destination) > float.Epsilon)
        {
            Vector2 velocity = Vector2.zero;
            this.transform.position = Vector2.MoveTowards(this.transform.position, m_destination, Time.deltaTime / moveTime);
            yield return new WaitForEndOfFrame();
        }

        m_isMoving = false;
    }

    /// <summary>
    /// �R���[�`���ɂ�銊�炩�Ȉړ��������L�����Z�����ĖړI�n�ɏu�Ԉړ�������B
    /// </summary>
    public void Skip()
    {
        if (m_isMoving)
        {
            StopAllCoroutines();
            this.transform.position = (Vector2)m_destination;
            m_isMoving = false;
        }
    }
}

