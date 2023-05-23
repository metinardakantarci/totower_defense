using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarKontrol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "dusman")
        {
            GetComponentInParent<Silah>().RadarGiris(other);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "dusman")
        {
            GetComponentInParent<Silah>().RadarCikis(other);
        }
    }
}
