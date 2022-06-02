using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    int jumpcount = 1;
    private Rigidbody2D rb;

    private float direction = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpcount = 1;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        if (direction > 0f)
        {
            sprite.flipX = false;
        }
        else if (direction < 0f)
        {
            sprite.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && jumpcount == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpcount = 0;
        }

        if (rb.position.y < -15f)
        {
            FindObjectOfType<game_manager>().EndGame();
        }
    }
}