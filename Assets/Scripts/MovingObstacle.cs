using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
<<<<<<< HEAD:Assets/MovingObstacle.cs
    private float maxTime = 0.75f;
=======
    [SerializeField]
    private float maxTime = 1f;
>>>>>>> 231bbbd79712acb9ba7b2bb41d3cb93c1cc4fd5c:Assets/Scripts/MovingObstacle.cs
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= maxTime)
        {
            transform.Translate(Vector2.right * Time.deltaTime * 1f);
        }

        else if (timer > maxTime - 0.2f)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 1f);

            if (timer > maxTime * 2)
                timer = 0f;
        }
    }

}
