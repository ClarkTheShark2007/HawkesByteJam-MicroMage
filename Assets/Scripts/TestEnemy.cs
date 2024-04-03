using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public Transform target;
    public float chaseRaidus;
    public float attackRadius;
    public Transform homePosition;

    public Rigidbody2D Rigid;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance () 
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRaidus && Vector3.Distance(target.position, transform.position) > attackRadius) 
        {
            Rigid.transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) 
    {
        //if(collision.tag == "Player") 
        {
        }
    }
}
