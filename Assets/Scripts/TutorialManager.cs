using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private TalkManager talkManager;
    private GameObject talkPanal;
    [SerializeField]  private RectTransform arrowPyo;
    [SerializeField] private Text talkText;
    private int talkIndex;


    private void Start()
    {
        talkManager = FindObjectOfType<TalkManager>();
        StartCoroutine(TutorialMain());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
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
        for(int i = 0; i < 13; i++)
        {
            Talk(i);
            if(i == 0)
            {
                yield return new WaitForSeconds(5f);
            }
            else if(i == 2)
            {
                arrowPyo.gameObject.SetActive(true);
                arrowPyo.position = new Vector3(56.4f, 9.5f);
                yield return new WaitForSeconds(5f);
                arrowPyo.gameObject.SetActive(false);
            }
            else if(i == 3)
            {
                arrowPyo.gameObject.SetActive(true);    
                arrowPyo.position = new Vector3(-395f, 367f);
                yield return new WaitForSeconds(5f);
            }
            else if(i == 4)
            {
                arrowPyo.gameObject.SetActive(true);
                Debug.Log(arrowPyo.transform.position); //= new Vector3(97.8f, 8.4f);
                yield return new WaitForSeconds(5f);
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
        }
        
        
        
        
    }
}
