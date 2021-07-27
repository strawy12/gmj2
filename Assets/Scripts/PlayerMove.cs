using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float jumpPower = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private LayerMask layerMask;

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

        if(Input.GetKey(KeyCode.LeftShift)/* && IsGrounded()*/)
        {
            transform.localScale = new Vector3(1.4f, 0.6f, 1.4f);
        }

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
    }
}
