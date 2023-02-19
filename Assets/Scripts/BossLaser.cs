using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField]
    float spinSpeed;

    [SerializeField]
    GameObject particleObj;

    const string TARGET_TAG = "Player";

    Vector3 scale;

    [HideInInspector]
    public float curZ;

    private void OnEnable()
    {
        scale = Vector3.zero;

        scale.y = 0.3f;
        
        transform.localScale = scale;

        transform.rotation = Quaternion.identity;

        StartCoroutine(LaserStart());
    }

    IEnumerator LaserStart()
    {
        particleObj.SetActive(true);

        while (transform.localScale.x < 15f)
        {
            scale.x += Time.deltaTime * 50f;

            transform.localScale = scale;

            yield return null;
        }

        StartCoroutine(LaserSpin());
    }

    IEnumerator LaserSpin()
    {
        while (curZ <= 360)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, curZ);
            curZ += Time.deltaTime * spinSpeed;
            yield return null;
        }

        curZ = 0;

        particleObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TARGET_TAG))
        {
            collision.gameObject.GetComponent<Unit>().Hit(10f);
        }
    }
}
