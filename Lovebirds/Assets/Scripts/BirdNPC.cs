using UnityEngine;

public class BirdNPC : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject instance;

    private RandomBird rB;

    private void Start()
    {
        instance = Instantiate(prefab, transform.position, Quaternion.identity);
        rB = instance.GetComponent<RandomBird>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TEST_PLAYER_TAG"))
        {
            Destroy(gameObject);
            rB.set = true;
        }
    }
}
