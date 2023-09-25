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
    Animator _animator;
    //移動する方向
    public ReactiveProperty<Vector2> _moveVec = new();
    float x;
    float y;
    bool _moving = false;
    bool _button = false;
    //音について
    public AudioClip _moveSound1;
    public AudioClip _moveSound2;
    //連射対策
    [SerializeField] float _interval = 1f;
    bool timer = true;
    float time = 0f;
    //向いている方向
    bool buttonFlag = false;
    //string direction = "forward";
    Vector2 _direction = new Vector2(0, 1);
    public LayerMask _blockingLayer;
    [SerializeField] GameObject direction;

    public int wallDamage = 1;
    public int enemyDamage = 5;
    void Start()
    {
        m_gridMove = GetComponent<GridMoveController>();
        _playerStatas = GetComponent<PlayerStatas>();
        _animator = GetComponent<Animator>();
        //direction = GameObject.Find("Direction").GetComponent<GameObject>();
        //MoveTranstion();
    }

    void Update()
    {
        //向きを変える機能
        if(Input.GetMouseButton(1))
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up ;
                direction.transform.position = new Vector3(0, 1, 0) + this.gameObject.transform.position;
                direction.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector2.left;
                direction.transform.position = new Vector3(-1, 0, 0) + this.gameObject.transform.position;
                direction.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector2.down;
                direction.transform.position = new Vector3(0, -1, 0) + this.gameObject.transform.position;
                direction.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector2.right;
                direction.transform.position = new Vector3(1, 0, 0) + this.gameObject.transform.position;
                direction.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
            _animator.SetTrigger("PlayerChop");
            TurnManager.EndTurn();
        }

        if(timer && !(Input.GetMouseButton(1)))
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
                    timer = false;
                }
            }
            if (!m_gridMove.IsMoving && _moving)
            {
                _moving = false;
                TurnManager.EndTurn();
            }

        }

        if(!timer)
        {
            if(time > _interval)
            {
                time = 0;
                timer = true;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        
        //_moveVec.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnCanMove<T>(T component)
    {
        //if()
        //Wall hitWall = component as Wall;
        //hitWall.DamageWall(wallDamage);
        //_animator.SetTrigger("PlayerChop");
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

    bool RayCast(out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + _direction;

        hit = Physics2D.Linecast(start, end, _blockingLayer);

        if (hit.transform == null)
        {
            return true;
        }
        return false;
    }

    void Attack()
    {
        RaycastHit2D hit;
        Vector2 start = this.transform.position;
        Vector2 end = start + _direction;

        hit = Physics2D.Linecast(end, end);
        Debug.DrawLine(start, end);
        if (hit.transform == null)
        {
            return;
        }

        if(hit.collider.CompareTag("Enemy"))
        {
            EnemyController hitEnemy = hit.transform.GetComponent<EnemyController>();
            hitEnemy.DamageEnemy(enemyDamage);
            //Destroy(hit.collider.gameObject);
        }
        else if(hit.collider.CompareTag("Wall"))
        {
            Wall hitWall = hit.transform.GetComponent<Wall>();
            //hitWall = hitWall as Wall;
            hitWall.DamageWall(wallDamage);
        }
        
    }
}
