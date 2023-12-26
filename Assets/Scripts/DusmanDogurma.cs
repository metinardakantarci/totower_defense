using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanDogurma : MonoBehaviour
{
    public GameObject[] dusmanlar;
    public Transform dogmaNoktasi;
    void Start()
    {
        InvokeRepeating("DusmanOlustur", 1, 4f);
    }

void DusmanOlustur()
{
    int randomIndex = Random.Range(0, dusmanlar.Length);
    GameObject yeniDusman = Instantiate(dusmanlar[randomIndex], dogmaNoktasi.position, Quaternion.identity);
}

}
