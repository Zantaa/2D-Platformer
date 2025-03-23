using UnityEngine;

public class GoldenPlatform : MonoBehaviour
{
    public bool canMove;

    [SerializeField]
    float speed;
    [SerializeField]
    public int startPoint;
    [SerializeField]
    public Transform[] points;

    private int i;
    public bool reverse;


    private void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;

            if (i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if(i == 0)
            {
                reverse = false;
                i++;
                return;
            }
            if(reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }
        if(canMove)
        {
            transform .position = Vector3.MoveTowards(transform.position, points[i].position, Time.deltaTime * speed);
        }
    }

}
