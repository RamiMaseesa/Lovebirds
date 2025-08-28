using System.Collections.Generic;
using UnityEngine;

public class RandomBird : MonoBehaviour {
    [SerializeField] GameObject[] bPrefab;

    public List<GameObject> currentBirds = new List<GameObject>();
    public bool set;

    private void Start() {
        set = true;
        SpawnBirds();
    }

    public void SpawnBirds() {
        // Always clear before spawning
        currentBirds.Clear();

        for (int i = 0; i < 5; i++) {
            int randB = Random.Range(0, bPrefab.Length);

            if (bPrefab[randB] != null) {
                float randPosX = Random.Range(-5f, 5.1f);
                float randPosY = Random.Range(-4f, 4.1f);

                // Instantiate bird
                GameObject newBird = Instantiate(bPrefab[randB], new Vector3(randPosX, randPosY, 1), Quaternion.identity);

                // Add the INSTANCE to the list
                currentBirds.Add(newBird);
            }
        }

        Debug.Log("Spawned " + currentBirds.Count + " birds.");
    }

    public void DeleteAllBirds() {
        // Destroy each bird
        foreach (GameObject go in currentBirds) {
            if (go != null) Destroy(go);
        }

        // Clear the list
        currentBirds.Clear();
    }
}
