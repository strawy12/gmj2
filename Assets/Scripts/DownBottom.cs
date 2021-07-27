using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBottom : MonoBehaviour
{

    Rigidbody2D rigid = null;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigid.gravityScale = 1;
        }
    }
}