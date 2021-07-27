using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private float angle = 0f;
    [SerializeField] private float maxAngle = 0f;

    private bool isStop = false;


    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void Update()
    {
        if (isStop) return;
        if (transform.localPosition.x - GameManager.Inst.playerMove.gameObject.transform.position.x < 6f)
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


}
