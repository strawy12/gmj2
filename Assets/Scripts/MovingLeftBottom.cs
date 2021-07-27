using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLeftBottom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        transform.Translate(Vector2.right * Time.deltaTime * 3f);
    }

   /* private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= maxTime)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 3f);
        }

        else if (timer > maxTime)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 3f);

            if (timer > maxTime * 2)
                timer = 0f;
        }
    }

}*/
}
