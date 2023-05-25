using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private LayerMask playerLayer;

    Transform player;
    Rigidbody2D rb;
    Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.gravityScale = 0f;
        rb.velocity = (player.position - transform.position) * shotSpeed;

        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            // TODO : 플레이어에 데미지
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
