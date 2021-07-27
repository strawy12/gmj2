using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBottomUpDown : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 1f;
    [SerializeField]
    private float speed = 3f;
    private float timer = 0f;
    [SerializeField]
    private bool downUp = true;

    private void Update()
    {
        timer += Time.deltaTime;

        if(downUp)
        {
            if (timer <= maxTime)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }

            else if (timer > maxTime)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);

                if (timer > maxTime * 2)
                    timer = 0f;
            }
        }

        else
        {
            if (timer <= maxTime)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }

            else if (timer > maxTime)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);

                if (timer > maxTime * 2)
                    timer = 0f;
            }
        }
        
    }
}
