using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsServer) return; // Hasar iþlemi sadece Server tarafýndan yapýlmalý

        PlayerManager player = other.GetComponent<PlayerManager>();
        if (player != null)
        {
            player.TakeDamageServerRpc(damage);
            GetComponent<NetworkObject>().Despawn();
        }

        Debug.Log("Bullet hit: " + other.gameObject.name);
    }
}
