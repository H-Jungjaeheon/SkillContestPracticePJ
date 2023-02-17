using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField]
    BasicEnemy basicEnemy;

    const string PLAYER = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER))
        {
            basicEnemy.playerObj = collision.gameObject;
        }
    }
}
