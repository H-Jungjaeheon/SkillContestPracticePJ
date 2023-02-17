using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashRotationBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Move()
    {

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
}
