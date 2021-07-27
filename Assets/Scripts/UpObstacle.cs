using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpObstacle : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] private float maxPosY;  

    void Start()
    {
        col = GetComponent<Collider2D>();
<<<<<<< HEAD

         maxPosY = transform.localPosition.y + maxPosY;
        
=======
        maxPosY = -2;
>>>>>>> cheoljin
    }

    void Update()
    {
        if (transform.localPosition.x - GameManager.Inst.PlayerMove.gameObject.transform.position.x < 3f)
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