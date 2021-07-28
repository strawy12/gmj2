using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPerSec : MonoBehaviour
{
    [SerializeField]
    private string direction;
    [SerializeField]
    private float second;
    [SerializeField]
    private float distance = 5f;
    [SerializeField]
    private float speed = 5f;
    private float timer = 0f;

    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x - GameManager.Inst.playerMove.gameObject.transform.position.x) > distance) return;
        if (timer > second) return;

        timer += Time.deltaTime;

        if (direction == "Down")
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        else if (direction == "Up")
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Obstacle"))
        {
            col.enabled = false;
        }
    }
}
