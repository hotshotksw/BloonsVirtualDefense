using Unity.VisualScripting;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    Player player;

    void Start()
    {
        print(player);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            player.TakeDamage(other.gameObject.GetComponent<K_Bloon>().damage);
            Destroy(other.gameObject);
        }
    }
}
