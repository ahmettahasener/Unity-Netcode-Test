using UnityEngine;
using Unity.Netcode;

public class XRBodyFollow : NetworkBehaviour
{
    public Transform xrCamera;
    public float heightOffset = -0.3f;

    private NetworkVariable<Vector3> syncedPosition = new NetworkVariable<Vector3>(
        writePerm: NetworkVariableWritePermission.Owner // Sadece sahibi güncelleyebilir
    );

    void Update()
    {
        if (IsOwner) // Sadece kendi pozisyonunu güncelleyebilsin
        {
            Vector3 pos = xrCamera.position;
            pos.y += heightOffset;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
            syncedPosition.Value = transform.position; // Deðiþikliði tüm client’lara gönder
        }
        else
        {
            transform.position = syncedPosition.Value; // Diðer oyuncularýn pozisyonunu al
        }
    }
}
