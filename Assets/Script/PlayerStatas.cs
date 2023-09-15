using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatas : MonoBehaviour
{
    [SerializeField] public int _hp;
    [SerializeField] int _power;
    [SerializeField] public int _maxHp = 100;
    st statas = st.Normal;
    public int _wallDamage = 1;
    public int _pointsPerFood = 10;
    public int _pointsPerSoda = 20;
    public float _restartLevelDelay = 1f;

    //‰¹‚É‚Â‚¢‚Ä
    public AudioClip _eatSound1;
    public AudioClip _eatSound2;
    public AudioClip _drinkSound1;
    public AudioClip _drinkSound2;
    public AudioClip _gameOverSound;

    Animator _animator;
    int _food;
    public Text _foodText;
    public enum st
    {
        Normal,
        Poison, 
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _food = GameManager._instance._foodPoint;
        _foodText.text = "Food: " + _food;
       // base.Start();
    }

    private void Update()
    {

    }
    private void OnDisable()
    {
        GameManager._instance._foodPoint = _food;
    }

    //protected override void AttempMove<T>(int xDir, int yDir)
    //{
    //    _food--;
    //    base.AttempMove<T>(xDir, yDir);
    //    RaycastHit2D hit;
    //    CheckGameOver();
    //    GameManager._instance._playersTurn = false;
    //}
    public void CheckGameOver()
    {
        if(_food <= 0)
        {
            SoundManager.instance.PlaySingle(_gameOverSound);
            SoundManager.instance._musicSource.Stop();
            GameManager._instance.GameOver();
        }
    }
    //protected override void OnCanMove<T>(T component)
    //{
    //    Wall hitWall = component as Wall;
    //    hitWall.DamageWall(_wallDamage);
    //    _animator.SetTrigger("PlayerChop");
    //}

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseFood(int loss)
    {
        _animator.SetTrigger("PlayerHit");
        _food -= loss;
        _foodText.text = "Food: " + _food;
        CheckGameOver() ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            Invoke("Restart", _restartLevelDelay);
            enabled = false;
        }
        else if(collision.gameObject.tag == "Food")
        {
            _food += _pointsPerFood;
            _foodText.text = "Food: " + _food;
            SoundManager.instance.RandomizeSfx(_eatSound1, _eatSound2);
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Soda")
        {
            _food += _pointsPerSoda;
            _foodText.text = "Food: " + _food;
            SoundManager.instance.RandomizeSfx( _drinkSound1, _drinkSound2);
            collision.gameObject.SetActive(false);
        }
    }

    public void FoodDes()
    {
        _food--;
        _foodText.text = "Food: " + _food;
    }
}
