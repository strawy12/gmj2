using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightObstacleMove : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] private float maxPosX = 0f;
    private bool isStop = true;
    void Start()
    {
        col = GetComponent<Collider2D>();
        if (transform.localPosition.y < 0)
        {
            maxPosX = transform.position.x + maxPosX;
        }
        else
        {
            maxPosX = transform.position.x - maxPosX;
        }

    }

    void Update()
    {
        if (transform.localPosition.x > maxPosX) return;
        if (GameManager.Inst.playerMove.gameObject.transform.position.x > transform.position.x  && VecComparison(GameManager.Inst.playerMove.gameObject.transform.position.x, transform.position.x))
        {
            isStop = false;
        }
        if (isStop) return;
        transform.Translate(Vector2.right * Time.deltaTime * 17f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
        }
    }
    private bool VecComparison(float a, float b)
    {
        float dist = a - b;
        if (dist > 4f)
        {
            return true;
        }
        return false;
    }
}
