using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite _dmgSprite;
    public int _hp = 4;

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        _spriteRenderer.sprite = _dmgSprite;
        _hp -= loss;
        if(_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
