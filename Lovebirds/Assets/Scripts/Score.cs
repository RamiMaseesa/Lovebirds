using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    public Pijltje1 pijltje;
    [SerializeField] TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        //pijltje = FindFirstObjectByType<Pijltje1>();
        //UpdateCoinsUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (pijltje.enabled == false) return;

        UpdateCoinsUI();

        if (pijltje.points == 20)//
        {
            FindFirstObjectByType<WinOrLoseEffect>().ActivateWin();
            FindFirstObjectByType<WinOrLoseEffect>().StartWinSong();
            FindFirstObjectByType<RandomBird>().DeleteAllBirds();
            FindFirstObjectByType<ActivateBarPlayer>().DisableBar();
            Destroy(FindFirstObjectByType<Timer>().gameObject);
            Destroy(this);
        }
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "Score: " + pijltje.points;
    }
}
