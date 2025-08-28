using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
