using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private TalkManager talkManager;
    private GameObject talkPanal;
    [SerializeField] private Text talkText;
    private int talkIndex;


    private void Start()
    {
        talkManager = FindObjectOfType<TalkManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Talk(talkIndex);
            talkIndex++;
        }
    }
    void Talk(int index)
    {
        string talkData = talkManager.GetTalk(100, index);

        talkText.text = talkData;
    }
}
