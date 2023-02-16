using UnityEngine;

public class EnemyBullet : Bullet
{
    Vector3 speedVector;

    private void Start()
    {
        speedVector.y = speed;
    }

    public override void Move()
    {
        transform.position -= speedVector * Time.deltaTime;
    }
}
