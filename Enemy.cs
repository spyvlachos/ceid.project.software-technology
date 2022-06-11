using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 1f;
    float delta = 31f;
    private float dirx;
    private Vector3 localscale;
    public bool rightmove;
    public int health = 3;

    public Rigidbody2D enem;
   
    // Start is called before the first frame update
    void Start()
    {
        localscale = transform.localScale;
        enem = GetComponent<Rigidbody2D>();
        dirx = -1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (rightmove)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale= new Vector2(-6, 6);
        }
        
        if(rightmove == false)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(6, 6);
        }

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "turn")
        {
            if (rightmove)
            {
                rightmove = false;
            }
            else
            {
                rightmove = true;
            }
        }
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }
    private void OnCollisionEnter2D(Collider2D collis)
    {
       if(collis.gameobject.tag == "magic")
        {
            TakeDamage();
        }
    }


}
