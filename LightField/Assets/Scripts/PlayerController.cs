using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /*---Script order---
     * Varables
     * --Start function--
     * --Update Funtion--
     * -Movement-
     * -Turn-
     * -Fire-
     * -Laser-
     * -UI-
     * --Fixed Update Function--
     * --On trigger enter function--
     */

    //Variables and other
    #region
    int LaserSelction;
    float FireTimer;
    GameObject CurrentLaser;

    [Header("--Ship Variables--")]
    public float Speed;
    public int health;

    [Header("--Lasers and Gun--")]
    public GameObject BlueLaser;
    public GameObject YellowLaser;
    public GameObject RedLaser;
    public Transform LaserSpawn1;
    public Transform LaserSpawn2;

    [Header("--UI--")]
    public Text PlayerHealth;
    public Text YouDied;
    public Text CurrentLaserSelection;
    #endregion

    void Start()
    {
        #region
        YouDied.gameObject.SetActive(false);
        FireTimer = 0;
        LaserSelction = 0;
        #endregion
    }

    void Update ()
    {
        #region
        if(health > 0)
        {
            Movement(); //how the player moves
            Turn(); //how the player turns
            Fire(); //how the player shoots
            Laser(); //How the player slects laser
        }      
        UI(); //UI for playership
        LoadScene(); //loading the start scene when the player dies
        #endregion
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
            Vector3 upAxis = new Vector3(0, 0, 1);
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = transform.position.z;
            Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            transform.LookAt(mouseWorldSpace, upAxis);
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        }
        #endregion
    }

    void Fire()
    {
        #region
        if(Input.GetAxis("LeftClick") > 0)
        {
            if(FireTimer <= 0)
            {
                Instantiate(CurrentLaser, LaserSpawn1.position, LaserSpawn1.rotation);
                Instantiate(CurrentLaser, LaserSpawn2.position, LaserSpawn2.rotation);
                FireTimer += 2;
            }
        }
        #endregion
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

    void UI()
    {
        #region
        PlayerHealth.text = "Health: " + health;  
        
        if(LaserSelction == 0)
        {
            CurrentLaserSelection.text = "Laser: Blue";
        }
        else if (LaserSelction == 1)
        {
            CurrentLaserSelection.text = "Laser: Yellow";
        }
        else if (LaserSelction == 2)
        {
            CurrentLaserSelection.text = "Laser: Red";
        }

        if (health <= 0)
        {
            YouDied.gameObject.SetActive(true);
        }
        #endregion
    }

    void LoadScene()
    {
        #region
        if(health <= 0)
        {
            if(Input.GetButtonDown("ESC"))
            {
                SceneManager.LoadSceneAsync("MainMenu");
            }
        }
        #endregion
    }

    void FixedUpdate()
    {
        #region
        if(FireTimer > 0)
        {
            FireTimer -= 1 * Time.fixedDeltaTime;
        }
        #endregion
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        #region
        if (other.gameObject.tag == "YellowEnemy")
        {
            health -= 1;
        }
        if(other.gameObject.tag == "BlueEnemy")
        {
            health -= 1;
        }
        if(other.gameObject.tag == "RedEnemy")
        {
            health -= 1;
        }
        #endregion
    }
}
