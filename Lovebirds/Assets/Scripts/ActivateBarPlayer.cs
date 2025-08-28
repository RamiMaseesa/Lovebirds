using Unity.VisualScripting;
using UnityEngine;

public class ActivateBarPlayer : MonoBehaviour
{
    [SerializeField] GameObject bar;
    private PlayerMovement playerMovement;
    

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ActivateBar() {
        bar.SetActive(true);
        playerMovement.playerSpeed = 0;
    }

    public void DisableBar() {
        bar.SetActive(false);
        playerMovement.playerSpeed = 4;
    }
}
