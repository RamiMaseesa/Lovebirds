using UnityEngine;

public class ActivateBar : MonoBehaviour
{
    [SerializeField] GameObject bar; 

    public void ActivateBarMethod() {
        bar.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
