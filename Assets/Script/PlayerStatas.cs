using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatas : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] int _sutamina;
    [SerializeField] int _power;
    st statas = st.Normal;
    
    public enum st
    {
        Normal,
        Poison, 
    }
    public void Damage(int damage)
    {
        _hp -= damage;
    }

    public void SutaminaDown(int down)
    {
        _sutamina -= down;
    }
}
