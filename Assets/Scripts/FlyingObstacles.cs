using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacles : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Inst.pool.MakeObj("obstacle_1");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.transform.position.x < 10f)
            Destroy(gameObject);
    }
}
