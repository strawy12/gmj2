using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private TalkManager talkManager;
    private GameObject talkPanal;
    private PlayerMove tutorialplayermove;
    [SerializeField] private RectTransform arrowPyo;
    [SerializeField] private Text talkText;
    private int talkIndex;


    private void Start()
    {
        talkManager = FindObjectOfType<TalkManager>();
        tutorialplayermove = FindObjectOfType<PlayerMove>();
        StartCoroutine(TutorialMain());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(arrowPyo.transform.position);

        }
    }
    void Talk(int index)
    {
        string talkData = talkManager.GetTalk(100, index);

        talkText.text = talkData;
    }

    private IEnumerator TutorialMain()
    {
        for (int i = 0; i < 17; i++)
        {
            Talk(i);
            if (i == 0)
            {
                yield return new WaitForSeconds(5f);
            }
            else if (i == 2)
            {
                arrowPyo.gameObject.SetActive(true);
                arrowPyo.anchoredPosition = new Vector3(-509f, 466f);
                yield return new WaitForSeconds(5f);
                arrowPyo.gameObject.SetActive(false);
            }
            else if (i == 3)
            {
                arrowPyo.gameObject.SetActive(true);
                arrowPyo.anchoredPosition = new Vector3(-405f, 368f);
                yield return new WaitForSeconds(5f);
                arrowPyo.gameObject.SetActive(false);
            }
            else if (i == 4)
            {
                arrowPyo.gameObject.SetActive(true);
                arrowPyo.anchoredPosition = new Vector3(-559f, 235f);//= new Vector3(97.8f, 8.4f);
                yield return new WaitForSeconds(5f);
                arrowPyo.gameObject.SetActive(false);

            }

            else if (i == 10)
            {
                yield return new WaitForSeconds(4f);
            }

            else if (i == 11 && tutorialplayermove.Gethp() == 3)
            {
                i += 1;
            }

            else if (i == 14)
            {
                yield return new WaitForSeconds(7f);
            }

            else
            {
                yield return new WaitForSeconds(3f);
            }






        }
    }
}