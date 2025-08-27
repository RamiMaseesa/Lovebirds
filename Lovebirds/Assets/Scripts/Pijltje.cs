using UnityEngine;

public class Pijltje1 : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed;
    [SerializeField] float maxLinks;
    [SerializeField] float maxRechts;
    private Rigidbody2D rb;
    float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        currentSpeed = speed;
    }
    void Update()
    {
        horizontal = gameObject.transform.localScale.x;
        if (gameObject.transform.position.x >= maxRechts)
        {
            print("rechts");
            currentSpeed = -speed;
        }
        if (gameObject.transform.position.x <= maxLinks)
        {
            print("links");
            currentSpeed = speed;
        }
        rb.linearVelocity = new Vector2(horizontal * currentSpeed, rb.linearVelocityY); //De velocity wordt op een nieuwe positie en de van de x speed wordt berekent.

    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.tag == "Red")
            {
                print("rood aanraak");
            }
            if (gameObject.tag == "Green")
            {
                print("Green aanraak");
            }

        }
    }
}
