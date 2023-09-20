using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove2 : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 2f;
    float x,y;
    float _time;
    Text _timeText;
    CinemachineVirtualCamera _vcam;
    [SerializeField] Text _textCountdown;
    bool _isCountdown;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _time = 0;
        _timeText = GameObject.Find("Time").GetComponent<Text>();
        _vcam = FindObjectOfType<CinemachineVirtualCamera>();
        _textCountdown = GameObject.Find("Countdown").GetComponent <Text>();
        _isCountdown = false;
        if ( _vcam != null)
        {
            _vcam.Follow = transform;
        }
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if( _isCountdown )
        {
            _time += Time.deltaTime;
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            _timeText.text = "Time:" + _time.ToString("F2");
        }
    }
    private void FixedUpdate()
    {
        if (x > 0)
        {
            _rb.velocity = Vector2.right * _moveSpeed;
        }
        if (x < 0)
        {
            _rb.velocity = Vector2.left * _moveSpeed;
        }
        if (y > 0)
        {
            _rb.velocity = Vector2.up * _moveSpeed;
        }
        if (y < 0)
        {
            _rb.velocity = Vector2.down * _moveSpeed;
        }
        if (x == 0 && y == 0)
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Exit"))
        {
            //ƒQ[ƒ€ƒNƒŠƒA‚Ìˆ—

        }
    }

    IEnumerator Countdown()
    {
        _textCountdown.gameObject.SetActive(true);
        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "Start!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);

        _isCountdown = true;
    }
}
