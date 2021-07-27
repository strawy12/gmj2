using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObj : MonoBehaviour
{
    private Collider2D col;
    private float maxPosY;
    [SerializeField]
    private float speed = 7f;

    void Start()
    {
        col = GetComponent<Collider2D>();
        maxPosY = 1.5f;
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 8f)
        {
            if (transform.localPosition.y > maxPosY)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }

            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
        }
    }
}
