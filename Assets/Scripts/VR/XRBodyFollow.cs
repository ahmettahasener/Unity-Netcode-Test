using UnityEngine;

public class XRBodyFollow : MonoBehaviour
{
    public Transform xrCamera;
    public float heightOffset = -0.3f;

    void Update()
    {
        Vector3 pos = xrCamera.position;
        pos.y += heightOffset;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
