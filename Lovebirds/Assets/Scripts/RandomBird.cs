using UnityEngine;

public class RandomBird : MonoBehaviour
{
    [SerializeField] GameObject[] bPrefab;

    public bool set;

    private void Start()
    {
        set = true;
    }

    private void Update()
    {
        int randB = Random.Range(0, bPrefab.Length); // Generates a random number between 0 and the amount of bird npcs.

        if (bPrefab[randB] != null && set) // If the prefab isn't null.
        {
            float randPosX = Random.Range(-5f, 5.1f);     // Random X spawn pos.
            float randPosY = Random.Range(-4f, 4.1f);     // Random Y spawn pos.
            Instantiate(bPrefab[randB], new Vector3(randPosX, randPosY, 1), Quaternion.identity);
            set = false;
        }
    }
}
