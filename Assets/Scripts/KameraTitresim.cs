using System.Collections;
using UnityEngine;

public class KameraTitresim : MonoBehaviour
{
    // Titreşim miktarı ve süresi
    public float titremeSiddeti = 0.1f;
    public float titremeSuresi = 0.1f;

    // Başlangıç pozisyonu
    private Vector3 ilkPozisyon;

    void Awake()
    {
        ilkPozisyon = transform.localPosition;
    }

    public void Titre()
    {
        StartCoroutine(TitremeYarat());
    }

    IEnumerator TitremeYarat()
    {
        float a = 0f;
        while (a < titremeSuresi)
        {
            // Rastgele bir pozisyon hesapla ve kameraya uygula
            Vector3 randomPosition = Random.insideUnitSphere * titremeSiddeti;
            transform.localPosition = ilkPozisyon + randomPosition;

            // Geçen süreyi artır ve bir sonraki frame için bekle
            a += Time.deltaTime;
            yield return null;
        }

        // Titreşim bittiğinde kamerayı başlangıç pozisyonuna geri yolla
        transform.localPosition = ilkPozisyon;
    }
}
