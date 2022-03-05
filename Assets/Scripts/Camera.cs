using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (!player)
        {
            return;
        }

        tempPos = transform.position;
        tempPos.x = player.position.x;

        minX = 2.5f;
        maxX = 500f;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        if (!Player.isPlayerBlocked)
        {
            transform.position = tempPos;
        }
    }
}
