using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle_1;
    [SerializeField] private GameObject obstacle_2;
    [SerializeField] private GameObject obstacle_3;
    [SerializeField] private GameObject obstacle_4;
    [SerializeField] private GameObject obstacle_5;
    [SerializeField] private GameObject obstacle_6;
    [SerializeField] private GameObject obstacle_7;
    [SerializeField] private GameObject obstacle_8;
    [SerializeField] private GameObject obstacle_9;
    [SerializeField] private GameObject obstacle_10;
    [SerializeField] private GameObject item_1;
    [SerializeField] private GameObject item_2;
    [SerializeField] private GameObject item_3;
    [SerializeField] private GameObject item_4;
    [SerializeField] private GameObject item_5;

    private List<GameObject> obstacle_1_List;
    private List<GameObject> obstacle_2_List;
    private List<GameObject> obstacle_3_List;
    private List<GameObject> obstacle_4_List;
    private List<GameObject> obstacle_5_List;
    private List<GameObject> obstacle_6_List;
    private List<GameObject> obstacle_7_List;
    private List<GameObject> obstacle_8_List;
    private List<GameObject> obstacle_9_List;
    private List<GameObject> obstacle_10_List;
    private List<GameObject> item_1_List;
    private List<GameObject> item_2_List;
    private List<GameObject> item_3_List;
    private List<GameObject> item_4_List;
    private List<GameObject> item_5_List;

    List<GameObject> targetPool_List;
    GameObject targetPool;


    private void Awake()
    {
        obstacle_1_List = new List<GameObject>();
        obstacle_2_List = new List<GameObject>();
        obstacle_3_List = new List<GameObject>();
        obstacle_4_List = new List<GameObject>();
        obstacle_5_List = new List<GameObject>();
        obstacle_6_List = new List<GameObject>();
        obstacle_7_List = new List<GameObject>();
        obstacle_8_List = new List<GameObject>();
        obstacle_9_List = new List<GameObject>();
        obstacle_10_List = new List<GameObject>();

        item_1_List = new List<GameObject>();
        item_2_List = new List<GameObject>();
        item_3_List = new List<GameObject>();
        item_4_List = new List<GameObject>();
        item_5_List = new List<GameObject>();
    }

   

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "obstacle_1":
                targetPool_List = obstacle_1_List;
                targetPool = obstacle_1;
                break;
            case "obstacle_2":
                targetPool_List = obstacle_2_List;
                targetPool = obstacle_2;
                break;
            case "obstacle_3":
                targetPool_List = obstacle_3_List;
                targetPool = obstacle_3;
                break;
            case "obstacle_4":
                targetPool_List = obstacle_4_List;
                targetPool = obstacle_4;
                break;
            case "obstacle_5":
                targetPool_List = obstacle_5_List;
                targetPool = obstacle_5;
                break;
            case "obstacle_6":
                targetPool_List = obstacle_6_List;
                targetPool = obstacle_6;
                break;
            case "obstacle_7":
                targetPool_List = obstacle_7_List;
                targetPool = obstacle_7;
                break;
            case "obstacle_8":
                targetPool_List = obstacle_8_List;
                targetPool = obstacle_8;
                break;
            case "obstacle_9":
                targetPool_List = obstacle_9_List;
                targetPool = obstacle_9;
                break;
            case "obstacle_10":
                targetPool_List = obstacle_10_List;
                targetPool = obstacle_10;
                break;
            case "item_1":
                targetPool_List = item_1_List;
                targetPool = item_1;
                break;
            case "item_2":
                targetPool_List = item_2_List;
                targetPool = item_2;
                break;
            case "item_3":
                targetPool_List = item_3_List;
                targetPool = item_3;
                break;
            case "item_4":
                targetPool_List = item_4_List;
                targetPool = item_4;
                break;
            case "item_5":
                targetPool_List = item_5_List;
                targetPool = item_5;
                break;
        }
        for (int i = 0; i < targetPool_List.Count; i++)
        {
            if (!targetPool_List[i].activeSelf)
            {
                targetPool_List[i].SetActive(true);
                return targetPool_List[i];
            }
        }
        if (targetPool == null)
        {
            return null;
        }
        int cnt = targetPool_List.Count - 1;
        targetPool_List.Add(Instantiate(targetPool));
        targetPool_List[cnt].transform.SetParent(transform);
        targetPool_List[cnt].SetActive(false);
        return targetPool_List[cnt];
    }
}
