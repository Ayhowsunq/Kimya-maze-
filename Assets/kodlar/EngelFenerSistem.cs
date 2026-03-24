using UnityEngine;
using TMPro;

public class EngelFenerSistem : MonoBehaviour
{
    public FenerSade fenerSade;
    
    [Header("Engel ve Mesaj")]
    public GameObject engel;          // Engel objesi (duvar, kapı vb.)
    public TextMeshProUGUI mesaj;     // TMP mesaj

    private bool oyuncuIcerde = false;
    private bool engelKaldirildi = false;

    void Start()
    {
        // Başlangıçta engel aktif
        if (engel != null)
            engel.SetActive(true);

        // Mesaj boş
        if (mesaj != null)
            mesaj.text = "";
    }

    void Update()
    {
        if (oyuncuIcerde && !engelKaldirildi)
        {
            // Sadece sahnedeki aktif feneri buluyoruz
            

            if (fenerSade != null && fenerSade.feneracikmi)
            {
                // Fener açık → engel kaldır ve bir daha gelmesin
                if (engel != null)
                    engel.SetActive(false);

                engelKaldirildi = true;

                if (mesaj != null)
                    mesaj.text = "";
            }
            else
            {
                // Fener kapalı → mesaj göster
                if (mesaj != null)
                    mesaj.text = "Çok karanlık...\nF ile ışığı aç";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu") && !engelKaldirildi)
        {
            oyuncuIcerde = true;
            // Burada engel.SetActive(false) yok, engel hep kalır
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            oyuncuIcerde = false;
            if (mesaj != null)
                mesaj.text = "";
        }
    }
}