using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Rendering;
using UnityEngine;

public class Pijltje1 : MonoBehaviour
{
    private ActivateBarPlayer barPlayer;

    private float horizontal;
    [SerializeField] float speed;
    [SerializeField] float maxLinks;
    [SerializeField] float maxRechts;
    public int points;
    private int fakePoint;
    private Rigidbody2D rb;
    float currentSpeed;
    bool spacePressed;
    bool hitRed = false;
    private RandomBird randomBird;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        currentSpeed = speed;
        points = 0;
        fakePoint = 0;

        barPlayer = FindFirstObjectByType<ActivateBarPlayer>();
        randomBird = FindFirstObjectByType<RandomBird>();
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
            fakePoint = 0;
            barPlayer.DisableBar();
            randomBird.DeleteAllBirds();
            randomBird.SpawnBirds();
        }
        else if (hitRed) {
            fakePoint = 0;
            hitRed = false;
            barPlayer.DisableBar();
            randomBird.DeleteAllBirds();
            randomBird.SpawnBirds();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //While being on the object
    {
        if (spacePressed && collision.gameObject.tag == "Red")
        {
            print("Red aanraak");
            print(points);
            hitRed = true;
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
