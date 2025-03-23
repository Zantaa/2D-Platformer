using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamge : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    //public int damage;

    public int maxHealth = 1;

    public float health;
    public GameObject heartPrefab;
    public Transform panelParent;
    public List<GameObject> hearts = new List<GameObject>();
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        health = maxHealth;
        for (int i = 0; i < health; i++)
        {
            hearts.Add(Instantiate(heartPrefab, panelParent));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hearts[(int)health - 1].GetComponent<Image>().sprite = emptyHeart;
            hearts.RemoveAt((int)health - 1);
            health -= 1;

            if (health <= 0)
            {
                Debug.Log("You have died!");

                SceneManager.LoadScene("MainMenu");
            }
        }
    }

}
