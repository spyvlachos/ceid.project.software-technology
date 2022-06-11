
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int jumpcount=1;
    private Rigidbody2D rb;
    public int charhealth = 5;
    private Transform player1;
    public GameObject magic;
    public GameObject Arrow;
    // public List<> hearts; 

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
        if(collision.gameObject.tag == "enemy")
        {
            losehealth();

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
        if (charhealth<= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<game_manager>().EndGame();

        }
        if (Input.GetKeyDown("m"))
        {
            CreateMagic();
        }
        if (Input.GetKeyDown("j"))
        {
            CreateArrow();
        }

        /*  if(charhealth < 1)
          {
              Destroy(hearts[0].gameobject);
          }
          if (charhealth < 2)
          {
              Destroy(hearts[1].gameobject);
          }
          if (charhealth < 3)
          {
              Destroy(hearts[2].gameobject);
          }
          if (charhealth < 4)
          {
              Destroy(hearts[3].gameobject);
          }
          if (charhealth < 5)
          {
              Destroy(hearts[4].gameobject);
          }*/

    }
    public void losehealth()
    {
        charhealth = charhealth - 1;
        rb.velocity *= -1;
    }
