using System.Collections;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField]
    protected int giveScore;

    [SerializeField]
    protected GameObject hitSpriteObj;

    [HideInInspector]
    public GameObject playerObj;

    const string DESTORY_ZONE = "DestoryZone";

    const string PLAYER = "Player";

    protected WaitForSeconds hitEffectDelay = new WaitForSeconds(0.05f);

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.down);
    }

    public override void Hit(float damage)
    {
        base.Hit(damage);

        StartCoroutine(HitColorEffect());
    }

    IEnumerator HitColorEffect()
    {
        hitSpriteObj.SetActive(true);

        yield return hitEffectDelay;

        hitSpriteObj.SetActive(false);
    }

    protected override void Dead()
    {
        BattleManager.instance.GetScore(giveScore);
        EnemySpawner.instance.EnemyDeadCount++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(DESTORY_ZONE) || collision.gameObject.CompareTag(PLAYER))
        {
            if (collision.gameObject.CompareTag(PLAYER))
            {
                collision.gameObject.GetComponent<Unit>().Hit(damage);
                Dead();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
