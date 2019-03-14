using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.RotateAround(transform.position, Vector3.up, Time.deltaTime);
    }
}
