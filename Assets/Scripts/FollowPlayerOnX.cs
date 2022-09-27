using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOnX : MonoBehaviour
{
    public Transform player;
    float xpos;
    // Update is called once per frame
    void Update()
    {
        xpos = player.position.x;
        transform.position = new Vector2(xpos, transform.position.y);
    }
}
