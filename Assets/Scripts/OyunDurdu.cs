using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunDurdu : MonoBehaviour
{

    public static bool oyunDurduMu = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(oyunDurduMu)
            {
                DevamEdiyor();
            }
            else
            {
                Durdu();
            }
        }
    }

    void Durdu()
    {
        oyunDurduMu = true;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    void DevamEdiyor()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        oyunDurduMu = false;
    }
}
