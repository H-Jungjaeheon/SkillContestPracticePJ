using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected float hp;

    public virtual float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            value = hp;
        }
    }

    [SerializeField]
    protected float damage;

    public bool isDontHit;


    public virtual void Hit(int damage)
    {
        if (isDontHit == false)
        {
            Hp -= damage;
        }
    }

    protected abstract void Dead();
}
