using UnityEngine;

public class RandomBird : MonoBehaviour
{
    [SerializeField] GameObject[] bPrefab;

    private void Start()
    {
        int rand = Random.Range(0, bPrefab.Length); // Generates a random number between 0 and the amount of bird npcs.

        if (bPrefab[rand] != null)
        {
            Instantiate(bPrefab[rand], transform.position, Quaternion.identity); // Spawns a random bird npc at the position of the empty game object.
        }
    }

    private void Update()
    { 

    }
}
