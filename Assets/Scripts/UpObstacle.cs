using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObstacle : MonoBehaviour
{
    private Collider2D col;
    private float maxPosY;  

    void Start()
    {
        col = GetComponent<Collider2D>();
        maxPosY = Random.Range(-3f, -4.5f);
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 8f)
        {
            if (transform.localPosition.y > maxPosY) return;

            transform.Translate(Vector2.up * Time.deltaTime * 7f);
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