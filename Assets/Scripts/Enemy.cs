using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField]
    int giveScore;

    WaitForSeconds hitEffectDelay = new WaitForSeconds(0.1f);

    Color hitEffectColor = Color.red;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit(int damage)
    {
        base.Hit(damage);

        StartCoroutine(HitColorEffect());
    }

    IEnumerator HitColorEffect()
    {
        hitEffectColor.a = 0;
        sr.color = hitEffectColor;

        yield return hitEffectDelay;

        hitEffectColor.a = 1;
        sr.color = hitEffectColor;
    }

    protected override void Dead()
    {
        BattleManager.instance.GetScore(giveScore);

        Destroy(gameObject);
    }
}
