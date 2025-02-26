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


    //protected override void OnActivate(XRBaseInteractor interactor)
    //{
    //    base.OnActivate(interactor);
    //    Shoot();
    //}

    public void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = muzzleTransform.forward * bulletSpeed;
    }
}
