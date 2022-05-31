using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationchar : MonoBehaviour
{
    public Transform attackpos;
    public float attackrange;
    public GameObject hittrig;
    public Animator hitchar;
    float timer = 0.0f;
    public LayerMask whatisenemy;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        hitchar = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackpos.position,attackrange,whatisenemy);
            for(int i=0; i<enemiestodamage.Length; i++)
            {
                enemiestodamage[i].GetComponent<enemy>().TakeDamage(damage);
            }

          
          
            hitchar.Play("player");
            

        }
    }
}
