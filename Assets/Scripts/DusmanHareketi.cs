using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DusmanHareketi : MonoBehaviour
{
    public Image canBar;                       // Düşmanın can çubuğunu temsil eden Image bileşeni
    public GameObject canvas;                   // Canvas objesini temsil eden GameObject
    public float toplamCan = 10;                // Düşmanın maksimum can miktarı
    public float mevcutCan = 10;                // Düşmanın mevcut can miktarı
    public GameObject efekt;                    // Patlama efektini temsil eden GameObject
    public GameObject efekt2;                   // Başka bir patlama efektini temsil eden GameObject
    Yonetici yonetici;                           // Yönetici scriptine erişmek için kullanılan referans
    GameObject kup;                              // Kup objesini temsil eden GameObject
    public int kupNumarasi;                      // Kup numarası
    public float hiz;                            // Düşmanın hareket hızı
    GameObject kamera;                           

    void Start()
    {
        kupNumarasi = 1;                        // Kup numarasını başlangıç değerine ayarla
        kamera = GameObject.Find("Main Camera"); // "Main Camera" adlı GameObject'i bul
        kup = GameObject.Find(kupNumarasi.ToString()); // Kup objesini bul
        yonetici = GameObject.Find("Yonetici").GetComponent<Yonetici>();    // "Yonetici" adlı GameObject'teki Yonetici scriptine eriş
        transform.LookAt(kup.transform);        // Düşmanı ilk başta kup objesine doğru döndür
    }

    private void Update() {
        GetComponent<Rigidbody>().velocity = transform.forward * hiz * Time.deltaTime; // Düşmanın ileri yönde hareket etmesini sağla
        canvas.transform.LookAt(kamera.transform); // Canvas objesini kameraya doğru döndür
    }   

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "kup")   // Eğer çarpışan obje "kup" tag'ine sahipse
        {
            kupNumarasi++;                      // Kup numarasını bir artır
            kup = GameObject.Find(kupNumarasi.ToString()); // Yeni kup objesini bul
            transform.LookAt(kup.transform);    // Düşmanı yeni hedefe doğru döndür
        }
        if(collision.gameObject.name == "VarisNoktasi") // Eğer çarpışan obje "VarisNoktasi" adına sahipse
        {
            yonetici._gecenDusman();             // Yönetici scriptindeki _gecenDusman() fonksiyonunu çağır
            Destroy(gameObject);                 // Düşman objesini yok et
        }
        if(collision.gameObject.tag == "Mermi")   // Eğer çarpışan obje "Mermi" tag'ine sahipse
        {
            canAzalt(2.0f);                      // Düşmanın canını azalt
            Destroy(collision.gameObject);       // Mermi objesini yok et
        }
    }

    public void canAzalt(float miktar)
    {
        mevcutCan -= miktar;                      // Düşmanın mevcut canını azalt
        canBar.fillAmount = mevcutCan / toplamCan; // Can çubuğunu güncelle

        if(mevcutCan <= 0)
        {
            yonetici.paraArttir(5);               // Yönetici scriptindeki paraArttir() fonksiyonunu çağır
            GameObject.Find("PatlamaSesi").GetComponent<AudioSource>().Play(); // Patlama sesini çal
            GameObject yeniEfekt = Instantiate(efekt, transform.position, Quaternion.identity); // Patlama efektini oluştur
            GameObject yeniEfekt2 = Instantiate(efekt2, transform.position, Quaternion.identity); // Başka bir patlama efektini oluştur
            Destroy(gameObject);                 // Düşman objesini yok et
        }
    }
}   
