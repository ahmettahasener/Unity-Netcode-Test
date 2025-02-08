using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        if (!IsOwner) return;
        Vector3 moveDirection = Vector3.zero;

        if(Input.GetKey(KeyCode.W)) moveDirection = Vector3.forward;
        if(Input.GetKey(KeyCode.A)) moveDirection = Vector3.left;
        if(Input.GetKey(KeyCode.S)) moveDirection = Vector3.back;
        if(Input.GetKey(KeyCode.D)) moveDirection = Vector3.right;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
