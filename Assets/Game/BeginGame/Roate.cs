using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Roate : MonoBehaviour
{
  public float RoateSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * RoateSpeed * Time.deltaTime);
    }
}
