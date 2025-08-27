using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    Pijltje1 pijltje;
    [SerializeField] TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        pijltje = FindFirstObjectByType<Pijltje1>();
        UpdateCoinsUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinsUI();

        if (pijltje.points == 10)
        {
            print("You won!");
        }
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "" + pijltje.points;
    }
}
