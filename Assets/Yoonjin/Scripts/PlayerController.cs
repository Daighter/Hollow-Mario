using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    private Animator anim;
    private SpriteRenderer render;
    private bool isGround;

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;
    // ���̾� ����ũ ����
    [SerializeField]
    LayerMask groundLayer;

    public Vector2 Dir { get { return dir; } }

    // �߷�, �ִϸ��̼�, ������ �ν��Ͻ� ����
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    // �̵� �Լ� ����
    private void Move()
    {
        if (dir.x < 0 && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(Vector2.right * dir.x * speed, ForceMode2D.Force);
        }

        else if (dir.x > 0 && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(Vector2.right * dir.x * speed, ForceMode2D.Force);
        }

        else if (dir.y < 0 && rb.velocity.y > -maxSpeed)
        {
            rb.AddForce(Vector2.up * dir.y * jumpPower, ForceMode2D.Force);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>();

        anim.SetFloat("moveSpeed", Mathf.Abs(dir.x));

        if (dir.x > 0)
        {
            render.flipX = false;
        }

        else if (dir.x < 0)
        {
            render.flipX = true;
        }
    }

    private void OnJump(InputValue value)
    {
        // �ߺ������� ���� ���� �׶��� üũ
        GroundCheck();
        if (isGround == true)
        {
            Jump();
        }
    }
  
    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);
        if (hit.collider != null)
        {
            isGround = true;
            anim.SetBool("IsGround", true);
            Debug.DrawRay(transform.position, new Vector3(hit.point.x, hit.point.y) - transform.position, Color.red);
        }

        else
        {
            isGround = false;
            anim.SetBool("IsGround", false);
            Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.green);
        }
    }
}