using UnityEngine;

public class RandomBird : MonoBehaviour
{
    int rand = Random.Range(1, 12); // Generates a random number between 1 and 11.

    private void Start()
    {
        GameObject bPrefab = Resources.Load<GameObject>($"BirdNPC-{rand}Prefab");

        if (bPrefab != null)
        {
            Instantiate(bPrefab/*, position*//*, rotation*/);
        }
    }

    private void Update()
    {

    }
}
