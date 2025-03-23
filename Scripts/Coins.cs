using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<AudioSource>().Play();
        }
    }
}
