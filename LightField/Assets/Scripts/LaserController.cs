using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{    
	void Update ()
    {
        transform.Translate(Vector2.up * 5 * Time.deltaTime, Space.Self);
	}
}
