using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float chaseRaidus;

    private float TimeBtwShots;

    public float StartTimeBtwShots;



    public Transform player;
    public GameObject projectile;

        public float attackRadius;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        TimeBtwShots = StartTimeBtwShots;

        
    }

    // Update is called once per frame
    void Update()
    {

        CheckDistance();
        
    void CheckDistance () 
    {
        if(Vector3.Distance(player.position, transform.position) <= chaseRaidus && Vector3.Distance(player.position, transform.position) > attackRadius) 
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) 
        {
            transform.position = this.transform.position;
            
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        }
    

        if(TimeBtwShots <= 0) {

            Instantiate(projectile, transform.position, quaternion.identity);
            TimeBtwShots = StartTimeBtwShots;

        }
            else 
            {
                TimeBtwShots -= Time.deltaTime;
            }
        }
    }
}


