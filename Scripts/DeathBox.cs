using Unity.VisualScripting;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = spawnPoint.position;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}
