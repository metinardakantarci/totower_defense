using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilahZemini : MonoBehaviour {
    ButonKontrol butonKontrol;                  // Buton kontrolü

    Color renk;                                // Orijinal renk

    private void Start() {
        butonKontrol = GameObject.Find("ButonKontrol").GetComponent<ButonKontrol>();  // ButonKontrol bileşenini al
        renk = GetComponent<MeshRenderer>().material.color;  // Orijinal rengi al
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            GetComponent<MeshRenderer>().material.color = renk;  // Fare sağ tuşuna basılı tutulduğunda orijinal rengi uygula
        }
    }

    private void OnMouseDown() {
        if (butonKontrol.secilenSilah == null) {
            GameObject[] tumZeminler = GameObject.FindGameObjectsWithTag("silahZemin");

            foreach (GameObject zemin in tumZeminler) {
                zemin.GetComponent<SilahZemini>().oncekiRenk();  // Tüm zeminlerin önceki rengine dön
            }

            GetComponent<MeshRenderer>().material.color = Color.green;  // Seçilen zemini yeşil renge ayarla

            butonKontrol.silahKoordinat = gameObject.transform;  // Seçilen silah zemininin koordinatını ayarla
            butonKontrol.tiklama(true, false, false);  // Buton kontrollerini ayarla
        }
    }

    public void oncekiRenk() {
        GetComponent<MeshRenderer>().material.color = renk;  // Önceki rengi uygula
    }
}
