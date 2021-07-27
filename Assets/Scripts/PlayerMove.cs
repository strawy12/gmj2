using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float jumpPower = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask layerMask;
<<<<<<< HEAD
    [SerializeField] private GameObject bottom = null;
    [SerializeField] private float gravity;
=======
>>>>>>> junseo

    private Transform cameraTransform;
    Rigidbody2D rigid = null;
    Collider2D col = null;
    SpriteRenderer spriteRenderer;

    private int jumpCnt = 0;
    private int maxCnt = 2;
    private int hp = 3;

    private bool isDamage = false;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        cameraTransform.position = new Vector3(transform.position.x + 7f, 0f, -10f);

<<<<<<< HEAD
        if (transform.position.y < cameraTransform.position.y - 7f)
        {
            transform.position = new Vector2(transform.position.x, cameraTransform.position.y + 3f);
            rigid.velocity = Vector2.zero;
            rigid.gravityScale = 0f;
            StartCoroutine(Damaged());
        }

        else
        {
            rigid.gravityScale = gravity;
        }

=======
>>>>>>> junseo
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

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.LeftShift) /*&& IsGrounded()*/) //사랑하는 우리 준무썜에게 물어볼꺼(물어보면서 같이 줌아웃 하는법 물어보기)
        {
            transform.localScale = new Vector3(1.4f, 0.6f, 1.4f);
            //transform.position = new Vector3(transform.position.x, -3.871605f, transform.position.z);
            if (Input.GetKey(KeyCode.LeftShift)/* && IsGrounded()*/)
            {
                transform.localScale = new Vector3(1.4f, 0.6f, 1.4f);
            }
=======
        if(Input.GetKey(KeyCode.LeftShift)/* && IsGrounded()*/)
        {
            transform.localScale = new Vector3(1.4f, 0.6f, 1.4f);
        }
>>>>>>> junseo

            else
            {
                transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(col.bounds.center, col.bounds.size, 180f, layerMask);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDamage) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (hp == 1)
            {
                GameManager.Inst.GameOver();
            }

            hp--;
            StartCoroutine(Damaged());
            UIManager.Inst.Hearts(hp);
        }
    }

    private IEnumerator Damaged()
    {
        isDamage = true;
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f)   ;
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        isDamage = false;
<<<<<<< HEAD
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
=======
>>>>>>> junseo
    }
}
