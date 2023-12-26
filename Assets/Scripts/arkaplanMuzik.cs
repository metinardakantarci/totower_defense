using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaplanMuzik : MonoBehaviour
{
    public static arkaplanMuzik muzik;

    private void Awake() {
        if(muzik != null)
        {
            Destroy(gameObject);
        }
        else
        {
            muzik = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
