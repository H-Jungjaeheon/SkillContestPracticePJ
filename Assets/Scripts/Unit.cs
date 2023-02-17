using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField]
    protected float maxHp;

    protected float hp;

    public virtual float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (value <= 0)
            {
                hp = 0;
                Dead();
            }
            else
            {
                hp = value;
            }
        }
    }

    [SerializeField]
    protected int damage;

    [SerializeField]
    protected float speed;

    public bool isDontHit;

    void Awake()
    {
        hp = maxHp;
    }

    public virtual void Hit(float damage)
    {
        if (isDontHit == false)
        {
            Hp -= damage;
        }
    }

    protected abstract void Dead();
}
