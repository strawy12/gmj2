using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOn : MonoBehaviour
{
    private int addy = 0;
    [SerializeField]
    private GameObject shoongPrefab;


    public void Start()
    {
        gameObject.SetActive(true);
        GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(shoongPrefab, new Vector3(20 , -2 + addy, 0), Quaternion.identity);
                addy += 1;
            }
            addy = 0;

            for (int i = 0; i < 4; i++)
            {
                Instantiate(shoongPrefab, new Vector3(28, -3 + addy, 0), Quaternion.identity);
                addy += 1;
            }
            addy = 0;

            for (int i = 0; i < 4; i++)
            {
                Instantiate(shoongPrefab, new Vector3(33 + addy, -3, 0), Quaternion.identity);
                addy += 1;
            }
            addy = 0;
        }
    }
    

    void Update()
    {
        
    }
}
