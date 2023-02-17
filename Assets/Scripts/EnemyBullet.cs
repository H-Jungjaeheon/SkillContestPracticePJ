using UnityEngine;

public class EnemyBullet : Bullet
{
    //Vector3 speedVector;

    private void Start()
    {
        //speedVector.y = speed;
    }

    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        //transform.position -= speedVector * Time.deltaTime;
    }
}
