using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    private Transform player1;
    private GameObject arrow;
    public float movespeeda = 3f;
    private List<Transform> arrowlist;
    private float newarrowposition;
    // Start is called before the first frame update
    void Awake()
    {
        arrowList = new List<Transform>();
    }
    void Start()
    {
        longattack = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + movespeeda, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    longattack.Play("arrow");

}