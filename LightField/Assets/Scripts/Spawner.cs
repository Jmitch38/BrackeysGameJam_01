using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public float WaitTimer;
    public float RepeatRate;

	void Start ()
    {
        InvokeRepeating("Spawn", WaitTimer, RepeatRate);
	}

    void Spawn()
    {
        int ran = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[ran], transform.position, transform.rotation);
    }
}
