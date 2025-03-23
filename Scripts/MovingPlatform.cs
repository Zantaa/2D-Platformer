using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform startingPosition, endPosition;
    bool atEnd = false;
    public float speed = 2.0f;

    void Update()
    {

        if (!atEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition.position, Time.deltaTime * speed);
        }
        if(transform.position.x == startingPosition.position.x)
        {
            atEnd = false;
        }
        else if(transform.position.x == endPosition.position.x)
        {
            atEnd = true;
        }

    }//end Update
}
