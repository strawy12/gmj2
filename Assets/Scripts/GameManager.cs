using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager inst;
    public static GameManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<GameManager>();
                if (inst == null)
                {
                    inst = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return inst;
        }
    }
    private void Awake()
    {
        GameManager[] gms = FindObjectsOfType<GameManager>();

        for (int i = 0; i < gms.Length; i++)
        {
            if (0 < i)
            {
                Destroy(gms[i].gameObject);
            }
        }
        DontDestroyOnLoad(gms[0].gameObject);
    }

    [SerializeField] GameObject[] stage = null;
    private float maxTime = 1f;
    private float scoreTimer = 0f;
    private float timer = 0f;
    private int jumpCnt = 4;
    private int stageNum = 0;

    private int nowScore;
    private int highScore;

    private float minPosY = -6f;
    public PlayerMove playerMove { get; private set; }
    public PoolManager pool { get; private set; }

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UIManager.Inst.UISetting(nowScore);

        playerMove = FindObjectOfType<PlayerMove>();
        pool = FindObjectOfType<PoolManager>();
        //StartCoroutine(SelectStage());
    }

    void Update()
    {
        scoreTimer += Time.deltaTime;

        if(scoreTimer > 1f)
        {
            nowScore += 30;
            scoreTimer = 0f;
            UIManager.Inst.UISetting(nowScore);
        }

        if (jumpCnt >= 4) return;

        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            timer = 0f;
            jumpCnt++;
        }
    }

    public float Timer()
    {
        return timer;
    }

    public float MaxTime()
    {
        return maxTime;
    }

    public int JumpCount()
    {
        return jumpCnt;
    }

    public void SetJumpCount()
    {
        jumpCnt--;
    }

    public float MinPosY()
    {
        return minPosY;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //private IEnumerator SelectStage()
    //{
    //    while (playerMove.GetHp() != 0)
    //    {
    //        stageNum = Random.Range(1, 11);

    //        stage[stageNum].transform.position = 
    //    }



    //}
}
