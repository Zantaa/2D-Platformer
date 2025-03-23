using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    public int startPoint;
    [SerializeField]
    public Transform[] points;

    private int i;
    public bool reverse;

    private Animator animator;


    private void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {

            if (i == points.Length - 1)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                reverse = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
                reverse = false;
                i++;
                return;
            }
            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }
        
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, Time.deltaTime * speed);

    }
}
