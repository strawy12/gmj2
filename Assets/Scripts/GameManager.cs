using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private float maxTime = 1f;
    private float timer = 0f;
    private int jumpCnt = 3;

    private float minPosY = -6f;
    public PlayerMove PlayerMove { get; private set; }
    public PoolManager pool { get; private set; }

    private void Start()
    {
        PlayerMove = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (jumpCnt >= 3) return;

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
}
