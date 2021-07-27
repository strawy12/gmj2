using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBottom : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 1f;
    [SerializeField]
    private float speed = 3f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= maxTime)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        else if (timer > maxTime)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);

            if (timer > maxTime * 2)
                timer = 0f;
        }
    }
}
