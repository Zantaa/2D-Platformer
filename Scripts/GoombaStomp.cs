using UnityEngine;

public class GoombaStomp : MonoBehaviour
{
    public int enemiesKilled;

    public bool isCreated;

    public Transform spawnPoint;
    public GameObject bossPrefab;

    public GameObject damageParticle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy Weak Point")
        {
            Instantiate(damageParticle, transform.position, Quaternion.identity);
            Debug.Log("You have killed an enemy Fly!");
            Destroy(collision.gameObject);
            enemiesKilled++;
        }
        if (!isCreated && enemiesKilled == 3)
        {
            Debug.Log("You have killed all the fly enemies! Boss has spawned!");
            Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            isCreated = true;

        }
    }
}
