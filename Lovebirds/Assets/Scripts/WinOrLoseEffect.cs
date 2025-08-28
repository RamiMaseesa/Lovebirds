using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class WinOrLoseEffect : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] music = new AudioClip[2];
    [SerializeField] GameObject particles;
    RainAndLightning sc;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject winObjectsEmpty;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject loseObjectsEmpty;

    // win
    [SerializeField] GameObject[] winObjects;

    // lose
    [SerializeField] GameObject[] loseObject;
    private float loseTime = 0;
    private bool failed = false;

    private void Start() {
        sc = GetComponent<RainAndLightning>();
        audioSource = GetComponent<AudioSource>();
        ActivateLose();
    }

    public void ActivateWin() {
        audioSource.clip = music[0];
        audioSource.Play();
        particles.SetActive(false);
        winObjectsEmpty.SetActive(true);
        sc.enabled = false;
        MoveTo(new Vector3(0, -13.1f, .8f), 30f, winText);
        // clouds
        MoveTo(new Vector3(-7.94000006f, 4.38999987f, 0), 5f, winObjects[0]);
        MoveTo(new Vector3(7.98999977f, 4.07999992f, 0), 7f, winObjects[1]);
        MoveTo(new Vector3(8.02999973f, -4.11999989f, 0), 6f, winObjects[2]);
        MoveTo(new Vector3(-7.90999985f, -4.26999998f, 0), 6f, winObjects[3]);
        // sun and rainbow
        MoveTo(new Vector3(0.140000001f, -4.80000019f, 0), 5f, winObjects[4]);
        MoveTo(new Vector3(0.129999995f, 6.07999992f, 0), 7f, winObjects[5]);
    }

    public void ActivateLose() {
        audioSource.clip = music[1];
        audioSource.Play();
        loseObjectsEmpty.SetActive(true);

        MoveTo(new Vector3(0, -13.1f, .8f), 30f, loseText);

        MoveTo(new Vector3(-6.96999979f, 3.63000011f, 0), 5f, loseObject[0]);
        MoveTo(new Vector3(7.5999999f, 4.07000017f, 0), 7f, loseObject[1]);

        MoveTo(new Vector3(-7.28999996f, -2.6099999f, 0), 5f, loseObject[4]);
        MoveTo(new Vector3(7.5f, -2.88000011f, 0), 7f, loseObject[5]);



        failed = true;

    }

    private void Update() {
        if (!failed) return;

        loseTime += Time.deltaTime;
        if (loseTime < 5) return;
        MoveTo(new Vector3(5.48000002f, 1.69000006f, 0), 1f, loseObject[2]);
        MoveTo(new Vector3(-4.92000008f, 0.930000007f, 0), 1f, loseObject[3]);
    }

    public void MoveTo(Vector3 targetPosition, float duration, GameObject gameObject) {
        StartCoroutine(LerpPosition(targetPosition, duration, gameObject));
    }


    private IEnumerator LerpPosition(Vector3 targetPosition, float duration, GameObject gameObject) {
        Vector3 startPosition = gameObject.transform.position;
        float elapsed = 0f;

        while (elapsed < duration) {
            // Progress from 0 → 1 over "duration"
            float t = elapsed / duration;

            // Move object smoothly
            gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Snap to final position (to avoid precision errors)
        gameObject.transform.position = targetPosition;
    }
}
