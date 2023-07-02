using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed of the player
    public float speed = 1.0f;
    //get the rigid body of the enemy
    private Rigidbody enemyRb;
    //get the player
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
