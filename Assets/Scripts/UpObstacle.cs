using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObstacle : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] private float maxPosY;
    [SerializeField] private float speed = 7f;

    void Start()
    {
        col = GetComponent<Collider2D>();
        maxPosY = transform.localPosition.y + maxPosY;
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 5f)
        {
            if (transform.localPosition.y > maxPosY) return;

            transform.Translate(Vector2.up * Time.deltaTime * speed);
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