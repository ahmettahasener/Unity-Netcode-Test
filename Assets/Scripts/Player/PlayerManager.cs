using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float healt = 100;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Player hit");
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        healt -= 25;
        if(healt <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(transform.parent.gameObject);//make player dead and respawn
    }
}
