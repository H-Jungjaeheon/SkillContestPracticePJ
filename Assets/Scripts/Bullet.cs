using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    string targetTag;

    const string DESTROY_ZONE = "DestoryZone";

    public float speed;

    public int damage;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) || collision.gameObject.CompareTag(DESTROY_ZONE))
        {
            if (collision.gameObject.CompareTag(targetTag))
            {
                collision.gameObject.GetComponent<Unit>().Hit(damage);
            }

            Destroy(gameObject);
        }
    }
}
