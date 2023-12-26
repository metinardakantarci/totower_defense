using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah : MonoBehaviour {
    public Transform silahKafasi;               // Silahın kafası
    public Transform mermiNoktasi;              // Mermi noktası

    public GameObject mermi;                    // Mermi prefabı
    List<Transform> hedef;                      // Hedef listesi

    KameraTitresim kameraTitresim;               // Kamera titremesi

    Transform mevcutHedef;                       // Mevcut hedef

    public int silahSeviye = 0;                  // Silah seviyesi
    float atesAraligi = 1f;                      // Ateş aralığı

    float yeniAtis = 0;                          // Yeni ateş zamanı
    bool ates = false;                           // Ateş durumu

    public AudioSource source;                   // Ses kaynağı
    public AudioClip atesSesi;                   // Ateş sesi

    public Transform radar;                      // Radar transformu

    ButonKontrol butonKontrol;                    // Buton kontrolü

    public int gelisimMaliyet = 15;               // Gelişim maliyeti
    public int yikimGetiri = 15;                  // Yıkım getirisi

    public GameObject efekt;                      // Efekt oyun objesi
    public int mermiHiz;                          // Mermi hızı

    private void Start() {
        hedef = new List<Transform>();           // Hedef listesini oluştur
        butonKontrol = GameObject.Find("ButonKontrol").GetComponent<ButonKontrol>();  // ButonKontrol bileşenini al
        SilahSeviye();                            // Silah seviyesini ayarla
        kameraTitresim = FindObjectOfType<KameraTitresim>();  // KameraTitresim bileşenini bul
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            radar.GetComponent<MeshRenderer>().enabled = false;  // Fare sağ tuşuna basılı tutulduğunda radarı gizle
        }

        if (mevcutHedef != null) {
            silahKafasi.LookAt(mevcutHedef);        // Mevcut hedefe doğru dön
        }

        if (ates == true) {
            if (Time.time > yeniAtis) {
                atesEt();                           // Ateş et
                yeniAtis = Time.time + atesAraligi;  // Yeni ateş zamanını ayarla
            }
        }
    }

    private void mermiUret() {
        source.PlayOneShot(atesSesi, 0.5f);          // Ateş sesini çal
        GameObject yeniMermi = Instantiate(mermi, mermiNoktasi.position, Quaternion.identity);  // Mermi oluştur
        yeniMermi.GetComponent<Rigidbody>().velocity = mermiNoktasi.forward * mermiHiz;         // Mermiye hız ver
        Destroy(yeniMermi, 1.0f);                   // Mermiyi belirli bir süre sonra yok et
    }

    private void atesEt() {
        if (mevcutHedef == null && ates == true) {
            for (int i = 0; i < hedef.Count; i++) {
                if (hedef[i] == null) {
                    hedef.RemoveAt(i);            // Hedef listeden çıkarılırsa, listeden sil
                }
            }

            if (hedef.Count > 0) {
                mevcutHedef = hedef[0];            // Hala hedefler varsa, mevcut hedefi belirle
            } else {
                ates = false;                      // Hedef yoksa ateşi durdur
                efekt.SetActive(false);            // Efekti gizle
            }
        }
        mermiUret();                               // Mermi üret
        kameraTitresim.Titre();                     // Kamera titremesini uygula
    }

    public void RadarGiris(Collider other) {
        efekt.SetActive(true);                      // Efekti göster
        hedef.Add(other.gameObject.transform);      // Hedefi listeye ekle
        mevcutHedef = hedef[0];                      // İlk hedefi mevcut hedef olarak ayarla
        ates = true;                                 // Ateşi etkinleştir
    }

    public void RadarCikis(Collider other) {
        hedef.Remove(other.gameObject.transform);   // Hedefi listeden çıkar
        if (hedef.Count > 0) {
            mevcutHedef = hedef[0];                  // Hala hedefler varsa, mevcut hedefi belirle
        } else {
            mevcutHedef = null;                      // Hedef yoksa mevcut hedefi null yap
            ates = false;                            // Ateşi durdur
            efekt.SetActive(false);                  // Efekti gizle
        }
    }

    public void SilahSeviye() {
        Invoke("RadarKapat", 1.0f);                  // Belirli bir süre sonra radarı kapat
        if (silahSeviye != 2) {
            silahSeviye++;                           // Silah seviyesini yükselt
            gelisimMaliyet += 15;                     // Gelişim maliyetini artır
            atesAraligi -= 0.1f;                       // Ateş aralığını azalt
            radar.localScale += new Vector3(1, 0, 1);  // Radarın ölçeğini artır
        }
    }

    public void RadarKapat() {
        radar.GetComponent<MeshRenderer>().enabled = false;  // Radarı gizle
    }

    private void OnMouseDown() {
        if (butonKontrol.silahKoordinat == null) {
            GameObject[] tumRadarlar = GameObject.FindGameObjectsWithTag("radar");

            foreach (GameObject radarlar in tumRadarlar) {
                radarlar.GetComponent<MeshRenderer>().enabled = false;  // Tüm radarları gizle
            }

            radar.GetComponentInChildren<MeshRenderer>().enabled = true;  // Seçilen radarı göster
            butonKontrol.secilenSilah = gameObject;                        // Seçilen silahı ayarla
            butonKontrol.tiklama(false, true, true);                       // Buton kontrollerini ayarla
        }
    }
}
