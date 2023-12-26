using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class btnFX : MonoBehaviour {

	public AudioSource efekt;
	public AudioSource efekt2;
	public AudioClip hoverFx;
	public AudioClip tıklamaEfekt;


	public void Hover()
	{
		efekt.PlayOneShot (hoverFx);
	}
	public void Tiklama()
	{
		efekt2.PlayOneShot (tıklamaEfekt);
	}
}
