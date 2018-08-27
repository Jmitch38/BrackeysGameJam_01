using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*---Script Hieracry---
     * Varables
     * --Start--
     * --Update Funtion--
     * -Movement-
     * -Turn-
     * -Fire-
     * -Laser-
     * --Fixed Update Function--
     */ 
    int LaserSelction;
    float FireTimer;
	[Header("--Ship Variables--")]
    public float Speed;
    public int health;
    [Header("--Lasers and Gun--")]
    GameObject CurrentLaser;
    public GameObject BlueLaser;
    public GameObject YellowLaser;
    public GameObject RedLaser;
    public Transform LaserSpawn1;
    public Transform LaserSpawn2;

    void Start()
    {
        FireTimer = 0;
        LaserSelction = 0;
    }

    void Update ()
    {
        Movement(); //how the player moves
        Turn(); //how the player turns
        Fire(); //how the player shoots
        Laser(); //How the player slects laser
	}

    void Movement()
    {
        #region
        if (Input.GetAxis("UpDown") > 0)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
        }
        else if (Input.GetAxis("UpDown") < 0)
        {
            transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
        }
        else
        {
            transform.Translate(0, 0, 0, Space.World);
        }
        if (Input.GetAxis("LeftRight") > 0)
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
        }
        else if (Input.GetAxis("LeftRight") < 0)
        {
            transform.Translate(-Speed * Time.deltaTime, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(0, 0, 0, Space.World);
        }
        #endregion
    }

    void Turn()
    {
        #region
        if (Input.GetAxis("LeftClick") > 0)
        {
            Vector3 upAxis = new Vector3(0, 0, -1);
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = transform.position.z;
            Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            transform.LookAt(mouseWorldSpace, upAxis);
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z + 180);
        }
        #endregion
    }

    void Fire()
    {
        if(Input.GetAxis("LeftClick") > 0)
        {
            if(FireTimer <= 0)
            {
                Instantiate(CurrentLaser, LaserSpawn1.position, LaserSpawn1.rotation);
                Instantiate(CurrentLaser, LaserSpawn2.position, LaserSpawn2.rotation);
                FireTimer += 2;
            }
        }
    }

    void Laser()
    {
        #region
        if (Input.GetButtonDown("RightClick"))
        {
            LaserSelction += 1;
            if (LaserSelction > 2)
            {
                LaserSelction = 0;
            }
        }

        if(LaserSelction == 0)
        {
            CurrentLaser = BlueLaser;
        }
        else if(LaserSelction == 1)
        {
            CurrentLaser = YellowLaser;
        }
        else if(LaserSelction == 2)
        {
            CurrentLaser = RedLaser;
        }
        #endregion
    }

    void FixedUpdate()
    {
        print(FireTimer);
        if(FireTimer > 0)
        {
            FireTimer -= 1 * Time.fixedDeltaTime;
        }
    }
}
