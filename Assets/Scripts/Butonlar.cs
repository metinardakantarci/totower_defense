using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butonlar : MonoBehaviour
{
    public RectTransform fader;
    /*private void Start() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1,1,1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
            fader.gameObject.SetActive(false);
        });
    }*/

    private void Update() {

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            arkaplanMuzik.muzik.GetComponent<AudioSource>().Pause();
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            arkaplanMuzik.muzik.GetComponent<AudioSource>().Pause();
        }
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            arkaplanMuzik.muzik.GetComponent<AudioSource>().Pause();
        }
        if(SceneManager.GetActiveScene().name == "EasterEgg")
        {
            arkaplanMuzik.muzik.GetComponent<AudioSource>().PlayDelayed(delay:1f);
        }
    }

    private void Start() {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3 (1,1,1), 0f);
        LeanTween.scale(fader, Vector3.zero, 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
            fader.gameObject.SetActive(false);
        });
    }

    public void SeviyeMenu()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
        SceneManager.LoadScene("SeviyeMenu");
        });
    }

    public void OyundanAyril()
    {
        Application.Quit();
    }

 
    public void Level1()
    {   
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
        SceneManager.LoadScene("Level1");
        });
    }
    
    /* Fade
            fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0,0);
        LeanTween.alpha(fader, 1,0.5f).setOnComplete(() =>{
        SceneManager.LoadScene("Level1");
        });
    */
    public void Level2()
    {   
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
        SceneManager.LoadScene("Level2");
        });
    }

    public void Level3()
    {   
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
        SceneManager.LoadScene("Level3");
        });
    }

    public void Menu()
    {   
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f ).setEase(LeanTweenType.easeInOutExpo).setOnComplete (() => {
        SceneManager.LoadScene("Menu");
        });
    }

 
}
