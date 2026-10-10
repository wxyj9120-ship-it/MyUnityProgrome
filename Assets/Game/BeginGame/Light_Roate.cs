using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Roate : MonoBehaviour
{
    public float RoateSpeed = 10f;
    public Transform Root;
    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(Root.position, Vector3.up, RoateSpeed * Time.deltaTime);
    }
}
