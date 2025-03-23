using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class PlatformerPlayer : MonoBehaviour
{
    //Golden Platform
    public Transform spawnPoint;
    public GameObject goldenPlatformPrefab;
    public bool isCreated;


    //Coin Managment
    [SerializeField]
    private TMP_Text coinsCollected;
    public Coins coinManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }//End Update Method

    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.coinCount++;
            coinsCollected.text = "Coins Collected: " + coinManager.coinCount + "/10";
        }
        if(!isCreated && coinManager.coinCount == 10)
        {
            Debug.Log("You have collected all the coins! Golden Platform has spawned!");
            Instantiate(goldenPlatformPrefab, spawnPoint.position, Quaternion.identity);
            isCreated = true;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
