using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    EnemySpawner enemySpawner;

    [Header("점수 관련")]
    [SerializeField]
    int score;

    [SerializeField]
    Text scoreText;

    [Header("스테이지 관련")]
    [SerializeField]
    int nowStage;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GetScore(int nowGetScore)
    {
        score += nowGetScore;
        scoreText.text = $"{score}";
    }

    void Start()
    {
        StartCoroutine(StageStartAnim());
    }

    IEnumerator StageStartAnim()
    {
        yield return null;
        enemySpawner.StartCoroutine(enemySpawner.enemySpawn());
    }

    public IEnumerator StageClear()
    {
        yield return null;
    }
}
