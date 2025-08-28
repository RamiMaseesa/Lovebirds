using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomBird : MonoBehaviour
{
    [SerializeField] GameObject[] bPrefab;

    public List<GameObject> currentBirds;
    public bool set;

    private void Start()
    {
        set = true;
        SpawnBirds();
    }
    
    private void SpawnBirds()
    {
        for (int i = 0; i < 5; i++)
        {
            int randB = Random.Range(0, bPrefab.Length); // Generates a random number between 0 and the amount of bird npcs.

            if (bPrefab[randB] != null && set) // If the prefab isn't null.
            {
                float randPosX = Random.Range(-5f, 5.1f);     // Random X spawn pos.
                float randPosY = Random.Range(-4f, 4.1f);     // Random Y spawn pos.
                currentBirds.Add(bPrefab[randB]);
                Instantiate(bPrefab[randB], new Vector3(randPosX, randPosY, 1), Quaternion.identity);
            }
        }
        set = false;

        for (int i = 0; i < currentBirds.Count; i++) {
            Debug.Log(currentBirds[i]);
        }
    }
}
