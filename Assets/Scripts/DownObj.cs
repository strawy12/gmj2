using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObj : MonoBehaviour
{
    private Collider2D col;
<<<<<<< HEAD
    [SerializeField] private float maxPosY;
=======
    private float maxPosY;
    [SerializeField]
    private float speed = 7f;
>>>>>>> minyoung

    void Start()
    {
        col = GetComponent<Collider2D>();
<<<<<<< HEAD
        
         maxPosY = transform.localPosition.y - maxPosY;
=======
        maxPosY = 1.5f;
>>>>>>> minyoung
    }

    void Update()
    {
<<<<<<< HEAD
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 0.8f)
        {
            if (transform.localPosition.y > maxPosY)
            {
                transform.Translate(Vector2.down * Time.deltaTime * 15f);
=======
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 8f)
        {
            if (transform.localPosition.y > maxPosY)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
>>>>>>> minyoung
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
<<<<<<< HEAD
}
=======
}
>>>>>>> minyoung
