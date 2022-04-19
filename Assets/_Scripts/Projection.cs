using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projection : MonoBehaviour
{
    public static Vector3 ProjectXZ()
    {
        Vector3 camForward = GameObject.FindGameObjectWithTag("MainCamera").transform.forward;
        Vector3 side = Vector3.Cross(camForward, Vector3.up).normalized;
        return Vector3.Cross(Vector3.up, side);
    }
}