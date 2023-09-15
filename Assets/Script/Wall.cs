using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite _dmgSprite;
    public int _hp = 4;
    public AudioClip _chopSound1;
    public AudioClip _chopSound2;

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        _spriteRenderer.sprite = _dmgSprite;
        _hp -= loss;
        SoundManager.instance.RandomizeSfx(_chopSound1, _chopSound2);
        if(_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
