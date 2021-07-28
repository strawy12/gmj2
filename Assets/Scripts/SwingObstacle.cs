using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private float angle = 0f;
    [SerializeField] private float maxAngle = 0f;

    private bool isStop = false;
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void Update()
    {
        if (isStop) return;
        if(transform.position.x -GameManager.Inst.playerMove.gameObject.transform.position.x < 6f)
        {
            if (angle > maxAngle)
            {
                angle -= speed * Time.deltaTime;
                if (angle < maxAngle) isStop = true;
            }
            else
            {
                angle += speed * Time.deltaTime;
                if (angle > maxAngle) isStop = true;
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);
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
