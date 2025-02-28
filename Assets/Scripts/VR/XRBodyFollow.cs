using UnityEngine;
using Unity.Netcode;

public class XRBodyFollow : NetworkBehaviour
{
    public Transform xrCamera;
    public float heightOffset = -0.3f;

    private NetworkVariable<Vector3> syncedPosition = new NetworkVariable<Vector3>(
        writePerm: NetworkVariableWritePermission.Owner // Sadece sahibi g�ncelleyebilir
    );

    void Update()
    {
        if (IsOwner) // Sadece kendi pozisyonunu g�ncelleyebilsin
        {
            Vector3 pos = xrCamera.position;
            pos.y += heightOffset;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
            syncedPosition.Value = transform.position; // De�i�ikli�i t�m client�lara g�nder
        }
        else
        {
            transform.position = syncedPosition.Value; // Di�er oyuncular�n pozisyonunu al
        }
    }
}
