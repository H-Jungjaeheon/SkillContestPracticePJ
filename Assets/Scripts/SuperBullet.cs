using System.Collections;
using UnityEngine;

public class SuperBullet : Bullet
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    RotatingBullet bullet2;

    [SerializeField]
    SpriteRenderer sr;

    Color color = Color.black;

    bool isStop;

    private void Start()
    {
        StartCoroutine(MovingShot());
    }

    protected override void Move()
    {
        if (isStop == false)
        {
            speed += Time.deltaTime * 2;
            transform.Translate(Time.deltaTime * speed * Vector2.down);
        }

        if (transform.position.y <= -5 && isStop == false)
        {
            isStop = true;

            color.a = 0;
            sr.color = color;

            StartCoroutine(SpawnBullet());
        }
    }

    IEnumerator MovingShot()
    {
        WaitForSeconds delay = new WaitForSeconds(0.3f);

        while (isStop == false)
        {
            for (int i = -90; i <= 90; i += 180)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, i));
            }

            yield return delay;
        }
    }

    IEnumerator SpawnBullet()
    {
        float shootDelay = 0.05f;
        float curCount = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int current = 0; current <= 360; current += 20)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, current));
            }

            if (i * 0.2 == 0)
            {
                for (int current = 0; current < 360; current += 40)
                {
                    var temp = Instantiate(bullet2, transform.position, bullet2.transform.rotation);
                    temp.SpawnSetting(current, 2.5f, 50f);
                }
            }

            while (curCount < shootDelay)
            {
                curCount += Time.deltaTime;
                yield return null;
            }

            curCount = 0f;
            shootDelay += 0.05f;
        }

        Destroy(gameObject);
    }
}
