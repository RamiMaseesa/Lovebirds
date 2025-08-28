using UnityEngine;

public class TutorialBirdSwap : MonoBehaviour
{
    [SerializeField] GameObject[] bPrefab;

    private bool go;

    private void Start()
    {
        go = true;
    }

    private void Update()
    {
        SpawnBirds();
        if (Input.GetKeyDown("space"))
        {
            go = true;
        }
    }
    private void SpawnBirds()
    {
        for (int i = 0; i < 5; i++)
        {
            int randB = Random.Range(0, bPrefab.Length); // Generates a random number between 0 and the amount of bird npcs.

            if (bPrefab[randB] != null && go) // If the prefab isn't null.
            {
                float randPosX = Random.Range(-5f, 5.1f);     // Random X spawn pos.
                float randPosY = Random.Range(-4f, 4.1f);     // Random Y spawn pos.
                Instantiate(bPrefab[randB], new Vector3(randPosX, randPosY, 1), Quaternion.identity);
            }
        }
        go = false;
    }
}
