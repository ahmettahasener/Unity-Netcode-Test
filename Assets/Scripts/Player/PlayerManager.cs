using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    [SerializeField] private int maxHealth = 4;
    private NetworkVariable<int> currentHealth = new NetworkVariable<int>(4, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private Vector3 spawnPoint;

    [SerializeField] private GameObject leftController;
    [SerializeField] private GameObject rightController;
    private void Start()
    {
        if (IsOwner)
        {
            spawnPoint = transform.position;
        }

        if (IsServer)
        {
            currentHealth.Value = maxHealth;
        }

    }

    [ServerRpc(RequireOwnership = false)]
    public void TakeDamageServerRpc(int damage)
    {
        if (currentHealth.Value > 0)
        {
            currentHealth.Value -= damage;
            Debug.Log($"Current Health: {currentHealth.Value}");

            if (currentHealth.Value <= 0)
            {
                Debug.Log("Player died. Respawning...");
                GetComponent<MeshRenderer>().enabled = false;
                StartRespawnServerRpc();

                //GetComponent<NetworkObject>().Despawn();
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void StartRespawnServerRpc()
    {
        Invoke(nameof(Respawn), 3f);
    }

    private void Respawn()
    {
        if (IsServer)
        {
            Debug.Log("Respawning player...");
            transform.position = spawnPoint;
            currentHealth.Value = maxHealth;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
