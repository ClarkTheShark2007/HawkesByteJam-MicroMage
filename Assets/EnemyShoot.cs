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

    private float TimeBtwShots;

    public float StartTimeBtwShots;



    public Transform player;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        TimeBtwShots = StartTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) 
        {
            transform.position = this.transform.position;
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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


