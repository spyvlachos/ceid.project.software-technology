using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int jumpcount=1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpcount==1)
        {
            rb.velocity = new Vector2(rb.velocity.x, 14);
            jumpcount = 0;
        }

        if(rb.position.y < -15f)
        {
            FindObjectOfType<game_manager>().EndGame();
        }
    }
}
