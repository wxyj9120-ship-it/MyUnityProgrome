using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public Transform Player;
    public int H = 12;
    public Vector3 pos;

    void LateUpdate()
    {
        if (Player == null)
        {
            return;
        }
        pos.x = Player.position.x;
        pos.y = H;
        pos.z = Player.position.z;
        this.transform.position = pos;
    }
}
