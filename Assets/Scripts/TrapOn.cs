using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOn : MonoBehaviour
{
    private float addy = 0f;
    [SerializeField]
    private GameObject shoongPrefab;

    public void Start()
    {
        gameObject.SetActive(true);
        GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomy = 0;
        randomy = Random.Range(-3, 2);
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(shoongPrefab, new Vector3(GameManager.Inst.PlayerMove.gameObject.transform.position.x+20+i, -2+addy, 0), Quaternion.identity);
                addy += 1f;
            }
            addy = 0f;

            for (int i = 0; i < 6; i++)
            {
                Instantiate(shoongPrefab, new Vector3(GameManager.Inst.PlayerMove.gameObject.transform.position.x + 24 + i, 4 + addy, 0), Quaternion.identity);
                addy -= 0.9f;
            }
            addy = 0f;
        }
    }

    void Update()
    {
      
    }
        
}
