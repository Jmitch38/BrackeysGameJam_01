using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllLasers : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BlueLaser")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RedLaser")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "YellowLaser")
        {
            Destroy(other.gameObject);
        }
    }
}
