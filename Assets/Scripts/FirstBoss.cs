using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [Header("소환 총알들 모음")]
    [SerializeField]
    GameObject bullet;

    [SerializeField] 
    RotatingBullet rotateBullet;

    [SerializeField]
    SuperBullet superBullet;

    [SerializeField]
    GameObject laserObj;

    WaitForSeconds pattonDelay = new WaitForSeconds(3.5f);

    IEnumerator rotatingMachineGun;

    IEnumerator nowSpinCoroutine;

    void Start()
    {
        isDontHit = true;
        StartCoroutine(StartAnim());
        nowSpinCoroutine = Spin();
    }

    IEnumerator StartAnim()
    {
        while (transform.position.y > 3)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        isDontHit = false;

        StartCoroutine(Pattons(Random.Range(0, 3)));
    }

    IEnumerator Pattons(int pattonIndex)
    {
        yield return pattonDelay;

        switch (pattonIndex)
        {
            case 0:

                StartCoroutine(RotatingBulletFire());

                rotatingMachineGun = RotatingMachineGun();
                StartCoroutine(rotatingMachineGun);

                break;
            case 1:

                SuperBulletFire();

                break;
            case 2:

                while (transform.position.y >= 0)
                {
                    transform.Translate(speed * Vector3.down * Time.deltaTime);
                }

                laserObj.SetActive(true);

                BossLaser laserComponent = laserObj.GetComponent<BossLaser>();

                StartCoroutine(CircleShot());

                while (laserComponent.curZ <= 360)
                {
                    yield return null;
                }

                laserObj.SetActive(false);

                while (transform.position.y < 3)
                {
                    transform.Translate(speed * Vector3.up * Time.deltaTime);
                }

                StartCoroutine(Pattons(Random.Range(0, 3)));

                break;

            case 3:

                break;
        }
    }

    protected override void Move()
    {
        if (transform.position.y > 3)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.down);
        }
    }

    IEnumerator CircleShot()
    {
        WaitForSeconds shotDelay = new WaitForSeconds(1.5f);

        int plusZ = 0;

        for (int i = 0; i < 7; i++)
        {
            for (int curZ = 0; curZ <= 360; curZ += 30)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, curZ + plusZ));
            }

            plusZ += 20;

            yield return shotDelay;
        }
    }

    IEnumerator Spin()
    {
        float spinSpeed = 500f;
        float curZ = 0;

        while (true)
        {
            curZ += Time.deltaTime * spinSpeed;

            transform.rotation = Quaternion.Euler(0f, 0f, curZ);

            yield return null;
        }
    }

    void SuperBulletFire()
    {
        Vector3 bulletPos = Vector3.zero;
        int randIndex = Random.Range(0, 2);

        bulletPos.x = (randIndex == 0) ? 2 : -2;
        Instantiate(superBullet, transform.position + bulletPos, superBullet.transform.rotation);

        StartCoroutine(Pattons(Random.Range(0, 3)));
    }

    IEnumerator RotatingBulletFire()
    {
        WaitForSeconds fireDelay = new WaitForSeconds(1.5f);
        float rotateSpeed = 50f;

        StartCoroutine(nowSpinCoroutine);

        for (int i = 1; i < 9; i++)
        {
            rotateSpeed *= -1;

            for (int current = 0; current < 360; current += 40)
            {
                var temp = Instantiate(rotateBullet, transform.position, rotateBullet.transform.rotation);
                temp.SpawnSetting(current, 2.5f, rotateSpeed);
            }

            yield return fireDelay;
        }

        StopCoroutine(rotatingMachineGun);

        StopCoroutine(nowSpinCoroutine);

        transform.rotation = Quaternion.identity;

        StartCoroutine(Pattons(Random.Range(0, 3)));
    }

    IEnumerator RotatingMachineGun()
    {
        WaitForSeconds fireDelay = new WaitForSeconds(0.3f);

        float plusZ = 0;

        while(true)
        {
            plusZ += 15;

            for (int current = 0; current < 360; current += 60)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, current + plusZ));
            }

            yield return fireDelay;
        }
    }
}
