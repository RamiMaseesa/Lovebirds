using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    [SerializeField] float playerSpeed;
    bool facingRight;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector3(playerSpeed * horizontal, vertical * playerSpeed);
        Flip();

        if (gameObject.transform.position.y >= 3.7f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 3.7f);
        }
        if (gameObject.transform.position.y <= -3.6f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3.6f);
        }
        if (gameObject.transform.position.x <= -8.08f)
        {
            gameObject.transform.position = new Vector2(-8.08f, gameObject.transform.position.y);
        }
        if (gameObject.transform.position.x >= 8.1f)
        {
            gameObject.transform.position = new Vector2(8.1f, gameObject.transform.position.y);
        }
    }

    private void Flip() //De flip methode
    {
        if (facingRight && horizontal > 0f || !facingRight && horizontal < 0f) //Het flipt de sprite naar de juiste directie
        {
            facingRight = !facingRight; //facingRight is niet gelijk aan FacingRight
            Vector3 localscale = transform.localScale; //De localscale van het transform component van de speler wordt opgehaald en opgeslagen in localscale
            localscale.x *= -1f; //De x component wordt vermenigvuldigd met -1 zodat het omdraait
            transform.localScale = localscale; //De aangepaste gegevens wordt doorgegeven aan de transform component van de player.
        }
    }
}
