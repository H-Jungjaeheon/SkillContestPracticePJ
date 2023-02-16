using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    int score;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
