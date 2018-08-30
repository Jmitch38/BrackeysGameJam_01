using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    GameObject ThePlayer;

    int BlueLaserDamage;
    int YellowLaserDamage;
    int RedLaserDamage;

    public int Health;
    public int speed;
    public bool BlueEnemy;
    public bool RedEnemy;
    public bool YellowEnemy;
    

    void Start()
    {
        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        if(BlueEnemy == true)
        {
            BlueLaserDamage = 3;
            YellowLaserDamage = 1;
            RedLaserDamage = 1;
        }
        else if(YellowEnemy == true)
        {
            BlueLaserDamage = 1;
            YellowLaserDamage = 3;
            RedLaserDamage = 1;
        }
        else if(RedEnemy == true)
        {
            BlueLaserDamage = 1;
            YellowLaserDamage = 1;
            RedLaserDamage = 3;
        }
        else
        {
            print("Script not setup correctly!");
        }
    }

    void Update()
    {
        Turn();
        Move();
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Turn()
    {
        Vector3 difference = ThePlayer.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BlueLaser")
        {
            Health -= BlueLaserDamage;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "YellowLaser")
        {
            Health -= YellowLaserDamage;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RedLaser")
        {
            Health -= RedLaserDamage;
            Destroy(other.gameObject);
        }
    }
}
