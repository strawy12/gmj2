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

    void Update()
    {
        timerFill.fillAmount = GameManager.Inst.Timer() / GameManager.Inst.MaxTime();
        jumpCount.text = string.Format("{0}", GameManager.Inst.JumpCount());
    }

    public void Hearts(int num)
    {
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            hearts.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < num; i++)
        {
            hearts.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
