using UnityEngine;

/// <summary>
/// TurnManager ����ʒm���󂯎�肽���ꍇ�͂�����p�����ăR���|�[�l���g����邱�ƁB
/// </summary>
public class TurnEventSubscriber : MonoBehaviour
{
    /// <summary>
    /// GameObject �� Active �ɂȂ鎞�ɌĂ΂��
    /// </summary>
    void OnEnable()
    {
        TurnManager.OnEndTurn += OnEndTurn;
        TurnManager.OnBeginTurn += OnBeginTurn;
    }

    /// <summary>
    /// GameObject ���� Active �ɂȂ鎞�ɌĂ΂��
    /// </summary>
    void OnDisable()
    {
        TurnManager.OnEndTurn -= OnEndTurn;
        TurnManager.OnBeginTurn -= OnBeginTurn;
    }

    /// <summary>
    /// �v���C���[�̃^�[���I�����̏���������
    /// </summary>
    public virtual void OnEndTurn()
    {
        
    }

    /// <summary>
    /// �v���C���[�̃^�[���J�n���̏���������
    /// </summary>
    public virtual void OnBeginTurn()
    {
        
    }
}
