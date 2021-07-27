using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObstacle : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rigid;

    private bool isStop = false;
    private bool isDestroy = false;

    void Start()
    {
        col = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 8.5f && !isStop)
        {
            if(!isDestroy)
            {
                StartCoroutine(DestroyObj());
                isDestroy = true;
            }

            isStop = true;
            rigid.gravityScale = 10f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0f;
            col.enabled = false;
        }
    }

    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}