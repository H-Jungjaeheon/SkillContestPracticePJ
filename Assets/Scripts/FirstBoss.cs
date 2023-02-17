using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : Enemy
{
    [SerializeField]
    GameObject bullet;

    [SerializeField] 
    RotatingBullet rotateBullet;

    WaitForSeconds pattonDelay = new WaitForSeconds(3.5f);

    IEnumerator rotatingMachineGun;

    // Start is called before the first frame update
    void Start()
    {
        isDontHit = true;
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        while (transform.position.y > 3)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(1f);

        isDontHit = false;

        StartCoroutine(Pattons(0));
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

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
        }
    }

    IEnumerator RotatingBulletFire()
    {
        WaitForSeconds fireDelay = new WaitForSeconds(1.5f);
        float rotateSpeed = 50f;

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

        StartCoroutine(Pattons(0));
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
