using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed; // speed of enemy, adjustable in unity b/c public

    private Transform target; // transform = position, rotation, e.t.c. of an obj
    // target b/c this will be the player's location
    
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // enemy's pos: transform
        if(Vector2.Distance(transform.position, target.position) < 4.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        // only go as fast as speed * deltaT
    }

    void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // find player, get position of player!
    }

}
