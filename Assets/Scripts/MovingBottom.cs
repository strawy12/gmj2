using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBottom : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 1f;
<<<<<<< HEAD
    [SerializeField]
    private float speed = 3f;
=======
>>>>>>> Cyeon
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= maxTime)
        {
<<<<<<< HEAD
            transform.Translate(Vector2.left * Time.deltaTime * speed);
=======
            transform.Translate(Vector2.left * Time.deltaTime * 3f);
>>>>>>> Cyeon
        }

        else if (timer > maxTime)
        {
<<<<<<< HEAD
            transform.Translate(Vector2.right * Time.deltaTime * speed);
=======
            transform.Translate(Vector2.right * Time.deltaTime * 3f);
>>>>>>> Cyeon

            if (timer > maxTime * 2)
                timer = 0f;
        }
    }
}
