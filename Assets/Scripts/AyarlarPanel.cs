using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyarlarPanel : MonoBehaviour
{
    public GameObject panel1;
    public void panel()
    {
        LeanTween.scale(panel1, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutExpo);
    }

    public void kapat()
    {
        LeanTween.scale(panel1, new Vector3(0,0,0), 0.5f).setEase(LeanTweenType.easeInOutExpo);
    }
}
