using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilgilendirmePanel : MonoBehaviour
{   
    public AudioSource pop;
    public AudioSource sayfa;

    public GameObject panel2;
    public GameObject panel1;
    
    private void Start() {
        Invoke("panel", 1f);
    }

    private void panel()
    {   
        pop.Play();
        LeanTween.scale(panel1, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutExpo);
    }

    public void SayfaDegis()
    {   
        sayfa.Play();
        LeanTween.scale(panel2, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutExpo);
        LeanTween.scale(panel1, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutExpo);
    }

    public void Kapat()
    {   
        pop.Play();
        LeanTween.scale(panel2, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutExpo);
    }
}
