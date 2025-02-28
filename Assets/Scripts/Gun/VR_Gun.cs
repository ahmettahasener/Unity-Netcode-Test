using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VR_Gun : XRGrabInteractable
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Transform muzzleTransform;
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        Debug.Log("Gun took");
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }
    public void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
        NetworkObject networkBullet = bullet.GetComponent<NetworkObject>();
        networkBullet.Spawn();

        // Server’a fizik iþlemlerini yaptýr
        ShootServerRpc(networkBullet.NetworkObjectId);
    }

    [ServerRpc(RequireOwnership = false)]
    private void ShootServerRpc(ulong bulletId)
    {
        NetworkObject bullet = NetworkManager.Singleton.SpawnManager.SpawnedObjects[bulletId];

        if (bullet != null)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = bullet.transform.forward * bulletSpeed;
        }
    }
}
