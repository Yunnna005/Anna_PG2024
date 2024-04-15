using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    protected Vector3 spawnPosition;

    protected virtual void TeleportPlayer(PlayerContoller player)
    {
        player.transform.position = spawnPosition;
    }
}
