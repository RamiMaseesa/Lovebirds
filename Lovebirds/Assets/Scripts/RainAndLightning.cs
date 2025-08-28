using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class RainAndLightning : MonoBehaviour {
    float rndtime;
    [SerializeField] GameObject lightning;

    AudioSource audioSource;
    [SerializeField] AudioClip[] thunderClips;

    void Start() {
        // Get the AudioSource from this GameObject
        audioSource = GetComponent<AudioSource>();

        // Schedule the first lightning
        ScheduleNextLightning();
    }

    void Update() {
        if (Time.time >= rndtime) {
            // Trigger lightning effect
            StartCoroutine(LightningEffect());

            // Schedule the next lightning strike
            ScheduleNextLightning();
        }
    }

    void ScheduleNextLightning() {
        float delay = UnityEngine.Random.Range(3f, 9f); // time between strikes
        rndtime = Time.time + delay;
    }

    System.Collections.IEnumerator LightningEffect() {
        int amount = UnityEngine.Random.Range(1, 4); // number of flashes

        for (int i = 0; i < amount; i++) {
            // Flash on
            lightning.SetActive(true);

            // Play thunder (random clip)
            if (thunderClips.Length > 0) {
                AudioClip clip = thunderClips[UnityEngine.Random.Range(0, thunderClips.Length)];
                audioSource.PlayOneShot(clip);
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f));

            // Flash off
            lightning.SetActive(false);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.4f));
        }
    }
}
