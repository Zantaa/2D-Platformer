using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.5f;
    [SerializeField]
    private float jumpForce = 12;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D box;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.linearVelocity.y);
        body.linearVelocity = movement;

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        body.gravityScale
            = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        GoldenPlatform goldenPlatform = null;

        if (hit != null)
        {
            goldenPlatform = hit.GetComponent<GoldenPlatform>();
        }
        
        if (goldenPlatform != null)
        {
            transform.parent = goldenPlatform.transform;
        }
        else
        {
            transform.parent = null;
        }

        animator.SetFloat("speed", Mathf.Abs(deltaX));

        Vector3 pScale = Vector3.one;

        if (goldenPlatform != null)
        {
            pScale = goldenPlatform.transform.localScale;
        }

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(
                Mathf.Sign(deltaX) / pScale.x,
                1 / pScale.y,
                1);
        }
    }
}
