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

    [SerializeField] GameObject[] stage = null;
    private GameObject stageObject = null;
    private float maxTime = 1f;
    private float timer = 0f;
    private int jumpCnt = 4;
    private int stageNum = 0;
    private int nowstageNum = 1;
    private int beforeStageNum = 1;

    private float minPosY = -6f;
    public PlayerMove playerMove { get; private set; }
    public PoolManager pool { get; private set; }

    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        pool = FindObjectOfType<PoolManager>();
        StartCoroutine(SelectStage());
    }

    void Update()
    {
        //if (jumpCnt >= 4) return;

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
    private void randNum()
    {
        stageNum = Random.Range(0, 10);
    }

    private IEnumerator SelectStage()
    {
        nowstageNum = 1;
        Vector2 stagePos = new Vector2(0f, -5.18f);
        stageObject = stageObject = Instantiate(stage[nowstageNum], stagePos, Quaternion.identity);
        stage[nowstageNum].SetActive(false);
        while (playerMove.GetHp() != 0)
        {
            randNum();
            
            stage[stageNum].gameObject.SetActive(true);

            if (nowstageNum == 0)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 160f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }
            else if (nowstageNum == 1)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 240f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 2)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 210f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 3)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 150f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 4)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 170f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 5)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 90f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 6)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 147.5f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 7)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 212f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 8)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 90f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }

            else if (nowstageNum == 9)
            {
                stagePos = new Vector2(stageObject.transform.position.x + 138f, -5.18f);
                stageObject = Instantiate(stage[stageNum], stagePos, Quaternion.identity);
            }
            stage[stageNum].SetActive(false);
            StartCoroutine(ReloadStage(stageObject));
            
            yield return new WaitForSeconds(15f);
            jumpCnt++;
            nowstageNum = stageNum;
            playerMove.SetSpeed(0.3f);

        }
    }


    private IEnumerator ReloadStage(GameObject stageObject)
    {
        yield return new WaitForSeconds(50f);
        Destroy(stageObject);
    } 

}
