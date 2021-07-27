using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedObstacle : MonoBehaviour
{
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
        }
    }
}
