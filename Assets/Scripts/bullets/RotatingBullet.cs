using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : Bullet
{
    [Tooltip("���� �˵� ����")]
    float radius;

    float angle;

    float sizeSpeed;

    float earlySizeSpeed; 

    float rotateSpeed;

    Vector3 startPos;

    Vector3 circularPos;

    public void Start()
    {
        startPos = transform.position;
        radius = 0;
    }
    
    /// <summary>
    /// ��ȯ �� ����
    /// </summary>
    /// <param name="rotate"></param>
    /// <param name="sizeSpd"></param>
    /// <param name="rotateSpd"></param>
    public void SpawnSetting(float startAngle, float sizeSpd, float rotateSpd)
    {
        angle = startAngle;
        
        sizeSpeed = sizeSpd;
        earlySizeSpeed = sizeSpd;

        rotateSpeed = rotateSpd;
    }

    protected override void Move()
    {
        angle += rotateSpeed * Time.deltaTime;
        radius += sizeSpeed * Time.deltaTime;

        circularPos.x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        circularPos.y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius; 

        transform.position = startPos + circularPos;

        if (sizeSpeed > earlySizeSpeed / 2)
        {
            sizeSpeed -= Time.deltaTime / 2;
        }
    }
}
