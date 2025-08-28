using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] float remainingtime;

    // Update is called once per frame
    void Update()
    {
        remainingtime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingtime / 60);
        int seconds = Mathf.FloorToInt(remainingtime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingtime < 0f) {
            FindFirstObjectByType<WinOrLoseEffect>().ActivateLose();
            FindFirstObjectByType<RandomBird>().DeleteAllBirds();
            FindFirstObjectByType<ActivateBarPlayer>().DisableBar();
            timerText.text = " ";
            Destroy(this);
        }
    }
}
