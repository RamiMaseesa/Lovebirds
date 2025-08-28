using UnityEngine;

public class ActivateBar : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("player")) {
            var player = collision.GetComponent<ActivateBarPlayer>();
            if (player != null) {
                player.ActivateBar();
            }
        }
    }
}
