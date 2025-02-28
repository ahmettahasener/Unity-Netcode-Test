using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRNetworkTransform : MonoBehaviour
{
    public Transform xrCamera;

    void Update()
    {
        Vector3 pos = xrCamera.position;
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }
}
