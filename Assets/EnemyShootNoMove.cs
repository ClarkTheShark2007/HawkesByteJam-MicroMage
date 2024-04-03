using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShootNoMove : MonoBehaviour
{
    private float TimeBtwShots;

    public float StartTimeBtwShots;



    public Transform player;
    public GameObject projectile;

    void Start()
    {
        TimeBtwShots = StartTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
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


