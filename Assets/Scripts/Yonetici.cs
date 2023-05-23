using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Yonetici : MonoBehaviour {
    public GameObject oyunBitti;          // Oyunun kaybedildiği durumda görünecek nesne
    public GameObject oyunKazanildi;      // Oyunun kazanıldığı durumda görünecek nesne

    DusmanHareketi dusmanHareketi;        // Düşman hareketi

    public int para = 100;                // Başlangıçta sahip olunan para miktarı

    public TextMeshProUGUI paraTxt;        // Para miktarını gösteren metin nesnesi
    public TextMeshProUGUI kalanSureTxt;   // Kalan süreyi gösteren metin nesnesi
    public TextMeshProUGUI gecenDusmanTxt; // Geçen düşman sayısını gösteren metin nesnesi

    int gecenDusman = 0;                   // Geçen düşman sayısı
    int gecmemesiGerekenDusman = 5;        // Kaybedilmek için geçilmesi gereken düşman sayısı
    int toplamSure = 60;                    // Oyundaki toplam süre

    private void Start() {
        paraTxt.text = "$" + para.ToString();  // Başlangıçta para miktarını göster

        gecenDusmanTxt.text = gecenDusman.ToString() + " / " + gecmemesiGerekenDusman.ToString();  // Başlangıçta geçen düşman sayısını göster

        InvokeRepeating("sureAzalt", 0, 1.0f);  // Her saniye sureAzalt() fonksiyonunu çağırarak süreyi azalt
    }

    public void sureAzalt() {
        toplamSure--;
        
        if (toplamSure <= 0) {
            CancelInvoke("sureAzalt");  // Süre tamamlandığında sureAzalt() fonksiyonunu iptal et
            
            oyunKazan();  // Oyunu kazanma durumunu tetikle
        }
        
        kalanSureTxt.text = toplamSure.ToString();  // Kalan süreyi güncelle
    }

    public void _gecenDusman() {
        gecenDusman++;
        gecenDusmanTxt.text = gecenDusman.ToString() + " / " + gecmemesiGerekenDusman.ToString();  // Geçen düşman sayısını güncelle

        if (gecenDusman >= gecmemesiGerekenDusman) {
            oyunKaybet();  // Oyunu kaybetme durumunu tetikle
        }
    }

    private void oyunKaybet() {
        LeanTween.scale(oyunBitti, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo);  // Oyunu kaybetme durumunda oyunBitti nesnesini büyüt ve görünür yap
    }

    private void oyunKazan() {
        LeanTween.scale(oyunKazanildi, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo);  // Oyunu kazanma durumunda oyunKazanildi nesnesini büyüt ve görünür yap
    }

    public void paraAzalt(int deger) {
        para -= deger;
        paraTxt.text = "$" + para.ToString();  // Para miktarını azalt ve paraTxt metin nesnesini güncelle
    }

    public void paraArttir(int deger) {
        para += deger;
        paraTxt.text = "$" + para.ToString();  // Para miktarını arttır ve paraTxt metin nesnesini güncelle
    }
}
