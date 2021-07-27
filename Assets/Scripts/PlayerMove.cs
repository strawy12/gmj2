using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float jumpPower = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject bottom = null;
    [SerializeField] private float gravity;

    private Transform cameraTransform;
    Rigidbody2D rigid = null;
    Collider2D col = null;
    SpriteRenderer spriteRenderer;

    private int jumpCnt = 0;
    private int maxCnt = 2;
    [SerializeField] private int hp = 3;
    private int gauge_AI = 0;

    private float origin_speed = 0f;
    private float origin_jumpPower = 0f;
    private float camera_lacalPositionY = 0f;

    private bool isDamage = false;
    private bool isShield = false;
    private bool isDouble = false;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        origin_speed = speed;
        origin_jumpPower = jumpPower;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.y) < Mathf.Abs(cameraTransform.position.y) - 7f)
        {
            transform.position = new Vector2(transform.position.x, cameraTransform.position.y + 3f);
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0f;
            StartCoroutine(Damaged());
            hp--;
            UIManager.Inst.SubHearts(hp);
        }

        else
        {
            rigid.gravityScale = gravity;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            if (GameManager.Inst.JumpCount() <= 0) return;

            GameManager.Inst.SetJumpCount();

            jumpCnt++;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCnt = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCnt < maxCnt && !IsGrounded())
        {
            if (GameManager.Inst.JumpCount() <= 0) return;

            if (jumpCnt == 1 && GameManager.Inst.JumpCount() <= 0)
            {
                return;
            }

            GameManager.Inst.SetJumpCount();

            jumpCnt++;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift) /*&& IsGrounded()*/)
        {
            transform.localScale = new Vector3(1.4f, 0.6f, 1.4f);
<<<<<<< HEAD
            //transform.position = new Vector3(transform.position.x, -3.871605f, transform.position.z)
        }
=======
            //transform.position = new Vector3(transform.position.x, -3.871605f, transform.position.z);
        }

>>>>>>> minyoung
        else
        {
            transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(col.bounds.center, col.bounds.size, 180f, layerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Item"))
        {
            switch (collision.gameObject.GetComponent<Item>().name)
            {
                case "Instargram":
                    isShield = true;
                    origin_speed = speed;
                    speed += 5f;
                    jumpPower += 8f;
                    rigid.gravityScale += 5f;
                    StartCoroutine(Instargram());
                    gauge_AI += 10;
                    break;

                case "Stair":
                    StartCoroutine(SpawnBottom());
                    gauge_AI += 10;
                    break;

                case "Baedal":
                    hp += 2;
                    //UIManager.Inst.AddHearts(hp);
                    gauge_AI += 10;
                    break;

                case "Message":
                    isDouble = true;
                    StartCoroutine(Message());
                    gauge_AI += 10;
                    break;

            }

            Destroy(collision.gameObject);
            UIManager.Inst.SetGauge_AI(gauge_AI);
            if (gauge_AI >= 100)
            {
                GameManager.Inst.GameOver();
            }
            else if (gauge_AI > 70)
            {

            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isDamage) return;

            if (hp == 1)
            {
                GameManager.Inst.GameOver();
            }

            hp--;
            StartCoroutine(Damaged());
            UIManager.Inst.SubHearts(hp);
        }
    }

    private bool VecComparison(Vector2 a, Vector2 b)
    {
        float dist = Vector2.Distance(a, b);
        if (dist < 0.15f)
        {
            return true;
        }
        return false;
    }

    private IEnumerator Damaged()
    {
        isDamage = true;

        if (isShield)
        {
            hp++;
        }

        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }

        isDamage = false;
    }

    private IEnumerator Instargram()
    {
        yield return new WaitForSeconds(3f);
        speed = origin_speed;
        jumpPower = origin_jumpPower;
        rigid.gravityScale = 5f;
        isShield = false;
    }
    private IEnumerator Message()
    {
        yield return new WaitForSeconds(10f);
        isDouble = false;
    }
    private IEnumerator SpawnBottom()
    {
        Vector2 curPos = Vector2.zero;
        for (int i = 0; i < 10; i++)
        {
            curPos = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.5f);
            Instantiate(bottom, curPos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
