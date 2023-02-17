using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    Vector3[] enemySpawnPoses;

    [SerializeField]
    GameObject[] enemys;

    [SerializeField]
    GameObject boss;

    int posIndex;

    int entityIndex;

    int enemyDeadCount;

    public int EnemyDeadCount
    {
        get
        {
            return enemyDeadCount;
        }
        set
        {
            enemyDeadCount = value;

            if (value <= 15)
            {
                BossSpawn();
            }
        }
    }

    WaitForSeconds enemySpawnDelay = new WaitForSeconds(3f);

    public IEnumerator enemySpawn()
    {
        while (true)
        {
            posIndex = Random.Range(0, enemySpawnPoses.Length);
            entityIndex = Random.Range(0, enemys.Length);

            Instantiate(enemys[entityIndex], enemySpawnPoses[posIndex], enemys[entityIndex].transform.rotation);

            yield return enemySpawnDelay;
        }
    }

    void BossSpawn()
    {
        Instantiate(boss, enemySpawnPoses[2], boss.transform.rotation);
    }
}
