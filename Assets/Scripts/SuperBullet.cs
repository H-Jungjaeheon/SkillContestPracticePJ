using System.Collections;
using System.Collections.Generic;
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

    protected override void Move()
    {
        if (isStop == false)
        {
            speed += Time.deltaTime * 2;
        }

        if (bullet.transform.position.y <= -5)
        {
            isStop = true;

            color.a = 0;
            sr.color = color;

            StartCoroutine(SpawnBullet());
        }
        //angle += rotateSpeed * Time.deltaTime;
        //radius += sizeSpeed * Time.deltaTime;

        //circularPos.x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        //circularPos.y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        //transform.position = startPos + circularPos;

        //if (sizeSpeed > earlySizeSpeed / 2)
        //{
        //    sizeSpeed -= Time.deltaTime / 2;
        //}
    }

    IEnumerator SpawnBullet()
    {
        WaitForSeconds fireDelay = new WaitForSeconds(0.25f);

        float plusZ = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int current = 0; current < 360; current += 30)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, current + plusZ));
            }
            yield return fireDelay;
        }

        for (int current = 0; current < 360; current += 40)
        {
            var temp = Instantiate(bullet2, transform.position, bullet2.transform.rotation);
            temp.SpawnSetting(current, 2.5f, 50f);
        }

        Destroy(gameObject);
    }
}
