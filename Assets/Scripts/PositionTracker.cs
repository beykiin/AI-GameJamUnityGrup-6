using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    // Objenin konumlarını ve zamanlarını tutacak listeler
    private List<Vector3> konumlar;
    private List<float> zamanlar;

    // Konum kaydı ne sıklıkla alınacak (saniye)
    public float takipAraligi = 0.1f;

    // Ne kadar süreyle konumlar takip edilecek (saniye) // Geriye ışınlanılacak zaman
    public float takipSuresi = 2.0f;

    private float gecenZaman = 0.0f;
    private float toplamZaman = 0.0f;

    void Start()
    {
        // Listeleri oluşturuyoruz
        konumlar = new List<Vector3>();
        zamanlar = new List<float>();
    }

    void Update()
    {
        gecenZaman += Time.deltaTime;
        toplamZaman += Time.deltaTime;

        // Belli aralıklarla objenin konumunu kaydet
        if (gecenZaman >= takipAraligi)
        {
            konumlar.Add(transform.position);
            zamanlar.Add(toplamZaman);
            gecenZaman = 0.0f;
        }

        // Eski konumları listeden temizle (takip süresinin dışına çıkanları)
        while (zamanlar.Count > 0 && toplamZaman - zamanlar[0] > takipSuresi)
        {
            konumlar.RemoveAt(0);
            zamanlar.RemoveAt(0);
        }

        // "Z" tuşuna basınca ışınlanma olayını tetikle
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OncekiKonumaIşınlan();
        }
    }

    void OncekiKonumaIşınlan()
    {
        if (zamanlar.Count > 0)
        {
            // 2 saniye önceki konuma en yakın pozisyonu bul
            float hedefZaman = toplamZaman - takipSuresi;
            Vector3 enYakinKonum = konumlar[0];
            float enYakinZamanFarki = Mathf.Abs(hedefZaman - zamanlar[0]);

            for (int i = 1; i < zamanlar.Count; i++)
            {
                float zamanFarki = Mathf.Abs(hedefZaman - zamanlar[i]);
                if (zamanFarki < enYakinZamanFarki)
                {
                    enYakinZamanFarki = zamanFarki;
                    enYakinKonum = konumlar[i];
                }
            }

            // Objenin konumunu ışınla ve listeleri temizle
            transform.position = enYakinKonum;
            konumlar.Clear(); 
            zamanlar.Clear(); 
        }
    }
}