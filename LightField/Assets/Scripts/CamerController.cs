﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform player;

	void LateUpdate ()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
	}
}
