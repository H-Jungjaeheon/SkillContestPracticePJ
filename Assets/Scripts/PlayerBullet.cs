using UnityEngine;

public class PlayerBullet : Bullet
{
    //Vector3 speedVector;

    private void Start()
    {
        //speedVector.y = speed;
    }

    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        //transform.position += speedVector * Time.deltaTime;
    }
}
