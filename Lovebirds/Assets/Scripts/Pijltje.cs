using UnityEditor.Rendering;
using UnityEngine;

public class Pijltje1 : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed;
    [SerializeField] float maxLinks;
    [SerializeField] float maxRechts;
    public int points;
    private int fakePoint;
    private Rigidbody2D rb;
    float currentSpeed;
    bool spacePressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        currentSpeed = speed;
        points = 0;
        fakePoint = 0;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }

        if (fakePoint == 3) { 
            points++; 
        }
        else if (fakePoint < 0) {

        }
    }

    private void OnTriggerStay2D(Collider2D collision) //While being on the object
    {
        if (spacePressed && collision.gameObject.tag == "Red")
        {
            print("Red aanraak");
            print(points);
            fakePoint--;
            spacePressed = false;
        }

        else if (spacePressed && collision.gameObject.tag == "Green")
        {
            print("Green aanraak");
            print(points);
            fakePoint++;
            spacePressed = false;
        }

        spacePressed = false;
    }
}
