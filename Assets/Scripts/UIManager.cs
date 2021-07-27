using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager inst;
    public static UIManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<UIManager>();
                if (inst == null)
                {
                    inst = new GameObject("UIManager").AddComponent<UIManager>();
                }
            }
            return inst;
        }
    }
    private void Awake()
    {
        UIManager[] ums = FindObjectsOfType<UIManager>();

        for (int i = 0; i < ums.Length; i++)
        {
            if (0 < i)
            {
                Destroy(ums[i].gameObject);
            }
        }
        DontDestroyOnLoad(ums[0].gameObject);
    }

    [SerializeField]
    Image timerFill;
    [SerializeField]
    Text jumpCount;
    [SerializeField]
    GameObject hearts;
    [SerializeField]
    Slider gauge_AI;

    private int maxValue = 100;
    private int addHeart = 0;

    void Update()
    {
        timerFill.fillAmount = GameManager.Inst.Timer() / GameManager.Inst.MaxTime();
        jumpCount.text = string.Format("{0}", GameManager.Inst.JumpCount());
    }

    public void AddHearts(int num)
    {
        if (num > hearts.transform.childCount)
        {
            GameObject heart;
            int addnum = num - hearts.transform.childCount;
            for (int i = 0; i < hearts.transform.childCount; i++)
            {
                heart = hearts.transform.GetChild(i).gameObject;
                heart.SetActive(true);
                if (addnum != 0)
                {
                    heart.GetComponent<Image>().color = new Color(0, 0, 1);
                    addnum--;
                    addHeart++;
                }
            }
        }
    }
    public void SubHearts(int num)
    {
        if (addHeart != 0)
        {
            hearts.transform.GetChild(addHeart - 1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            addHeart--;
            return;
        }

        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            hearts.transform.GetChild(i).gameObject.SetActive(false);
        }

        //for (int i = 0; i < num; i++)
        //{
        //    hearts.transform.GetChild(i).gameObject.SetActive(true);
        //}
    }

    public void SetGauge_AI(int value)
    {
        gauge_AI.value = (float)value / (float)maxValue;
    }
}
