using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    string targetTag;

    public int speed;

    public int damage;

    private void Update()
    {
        Move();
    }

    public abstract void Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<Unit>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
