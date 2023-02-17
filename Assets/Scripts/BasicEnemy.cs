using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField]
    GameObject bullet;

    float fireRotateZ;
    float rotateZ;

    WaitForSeconds fireDelay = new WaitForSeconds(2f);

    void Start()
    {
        StartCoroutine(WaitForPlayerInRange());
    }

    protected override void Move()
    {
        transform.position += Time.deltaTime * speed * Vector3.down;
    }

    IEnumerator WaitForPlayerInRange()
    {
        while (true)
        {
            if (playerObj != null)
            {
                StartCoroutine(FireBullet());
                StartCoroutine(Watch());

                break;
            }

            yield return null;
        }
    }

    IEnumerator Watch()
    {
        while (true)
        {
            rotateZ = Mathf.Atan2(playerObj.transform.position.y - transform.position.y, playerObj.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0f, 0f, 90 + rotateZ);

            yield return null;
        }
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            yield return fireDelay;

            fireRotateZ = Mathf.Atan2(playerObj.transform.position.y - transform.position.y, playerObj.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
           
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 90 + fireRotateZ));
        }
    }
}
