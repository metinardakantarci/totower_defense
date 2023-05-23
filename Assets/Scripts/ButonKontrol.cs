using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonKontrol : MonoBehaviour
{   
    public GameObject silah;  // Oyundaki silahın prefab nesnesi
    public Transform silahKoordinat; // Silahın yerleştirileceği koordinat
    public GameObject secilenSilah;  // Seçilen silahın referansı

    public Button olusturButon; // Silah oluşturma butonu
    public Button gelistirButon; // Silah geliştirme butonu
    public Button yokEtButon; // Silah yok etme butonu

    Yonetici yonetici;                        

    private void Start() {
        yonetici = GameObject.Find("Yonetici").GetComponent<Yonetici>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1))
        {
            silahKoordinat = null;
            secilenSilah = null;
            tiklama(true, false, false); // Sağ tıklama yapıldığında butonları güncelle
        }    
    }

    public void SilahOlustur()
    {
        if(silahKoordinat != null)
        {
            int para = yonetici.para;
            if(para >= 25)
            {
                GameObject yeniSilah = Instantiate(silah, new Vector3(silahKoordinat.position.x, silahKoordinat.position.y + 1, silahKoordinat.position.z), Quaternion.identity);

                yonetici.paraAzalt(25); // Silah oluşturulduğunda para miktarını azalt

                silahKoordinat.gameObject.GetComponent<SilahZemini>().oncekiRenk();
                silahKoordinat = null;
            }
        }
    }

    public void SilahGelistir()
    {
        if(secilenSilah != null)
        {
            int gelisimMaliyet = secilenSilah.GetComponent<Silah>().gelisimMaliyet;
            int para = yonetici.para;

            if(para >= gelisimMaliyet)
            {
                secilenSilah.GetComponent<Silah>().SilahSeviye();
                yonetici.paraAzalt(gelisimMaliyet); // Silah geliştirildiğinde para miktarını azalt

                secilenSilah = null;
                tiklama(true, false, false); // Butonları güncelle
            }
        }
    }

    public void YokEt()
    {
        if(secilenSilah != null)
        {
            Destroy(secilenSilah); // Seçilen silahı yok et

            tiklama(true, false, false); // Butonları güncelle
            secilenSilah = null;

            yonetici.paraArttir(15); // Silah yok edildiğinde para miktarını arttır
        }
    }

    public void tiklama(bool olustur, bool gelistir, bool yokEt)
    {
        gelistirButon.interactable = gelistir; // Geliştirme butonunun etkinlik durumunu güncelle
        olusturButon.interactable = olustur; // Oluşturma butonunun etkinlik durumunu güncelle
        yokEtButon.interactable = yokEt; // Yok etme butonunun etkinlik durumunu güncelle
    }
}
