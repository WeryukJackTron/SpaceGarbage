using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinEarth : MonoBehaviour
{
    public float AngularVelocity = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float angle = Time.deltaTime * AngularVelocity;
        transform.Rotate(transform.up, angle, Space.World);
    }
}
