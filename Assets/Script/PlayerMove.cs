using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    public float _moveTime = 0.1f;
    public bool _isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vartical = (int)Input.GetAxisRaw("Vartical");

        if(horizontal != 0)
        {
            vartical = 0;
            if(horizontal == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(horizontal == -1) 
            {
                transform.localScale = new Vector3(-1, -1, -1);
            }
        }
        else if(vartical != 0)
        {
            horizontal = 0;
        }

        if(horizontal != 0 || vartical != 0)
        {
            Move(horizontal, vartical);
        }
    }

    public void Move(int horizontal, int vartical)
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + new Vector2(horizontal, vartical);

        if(!_isMoving)
        {
            StartCoroutine(MoveMent(endPos));
        }
    }

    IEnumerator MoveMent(Vector3 endPos)
    {
        _isMoving = true;
        float remainingDistance = (transform.position - endPos).sqrMagnitude;

        while(remainingDistance > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, 1f / _moveTime * Time.deltaTime);
            remainingDistance = (transform.position - endPos).sqrMagnitude;
            yield return null;
        }

        transform.position = endPos;

        _isMoving = false;
    }
}
