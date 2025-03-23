using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    GoldenPlatform goldPlatform;

    private void Start()
    {
        goldPlatform = GetComponent<GoldenPlatform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        goldPlatform.canMove = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        goldPlatform.canMove = true;
    }
}
