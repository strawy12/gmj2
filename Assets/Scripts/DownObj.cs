using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObj : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] private float maxPosY;
    [SerializeField]
    private float speed = 7f;

    [SerializeField] private float distance = 2f;

    void Start()
    {
        col = GetComponent<Collider2D>();
        maxPosY = transform.localPosition.y - maxPosY;
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.playerMove.gameObject.transform.position.x < distance)
        {
            if (transform.localPosition.y > maxPosY)
            {
                transform.Translate(Vector2.down * Time.deltaTime * 15f);
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
