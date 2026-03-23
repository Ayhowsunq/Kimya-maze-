using UnityEngine;
using TMPro;

public class EtkileşimMesaj : MonoBehaviour
{
    public TextMeshProUGUI mesaj;
    public string mesajMetni = "Anahtar gerekiyor!";
    public float fadeSpeed = 2f;

    private bool oyuncuYakinda = false;
    private float alpha = 0f;

    void Start()
    {
        // Başlangıçta görünmez yap
        Color c = mesaj.color;
        c.a = 0f;
        mesaj.color = c;
    }

    void Update()
    {
        // Smooth fade in/out
        float targetAlpha = oyuncuYakinda ? 1f : 0f;
        alpha = Mathf.MoveTowards(alpha, targetAlpha, fadeSpeed * Time.deltaTime);

        Color c = mesaj.color;
        c.a = alpha; // Alpha değerini koddan ayarlıyoruz
        mesaj.color = c;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            oyuncuYakinda = true;
            mesaj.text = mesajMetni;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            oyuncuYakinda = false;
        }
    }
}