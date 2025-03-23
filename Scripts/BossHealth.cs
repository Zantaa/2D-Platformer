using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int bossHP = 3;

    public GameObject damageParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss Weak Point")
        {
            Instantiate(damageParticle, transform.position, Quaternion.identity);
            Debug.Log("You have hurt the boss!");
            bossHP--;
        }
        if (bossHP == 0)
        {
            Debug.Log("You have killed the SLIME BOSS!");
            Destroy(collision.gameObject);
            bossHP = -1;

            SceneManager.LoadScene("GameOver");

        }
    }
}
