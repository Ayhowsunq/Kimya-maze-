using UnityEngine;
using TMPro;

public class InteractMesaj : MonoBehaviour
{
    public TextMeshProUGUI mesaj;
    public string mesajMetni = "Anahtar gerekiyor!";
    public float fadeSpeed = 2f;

    private float alpha = 0f;
    private bool goster = false;

    void Start()
    {
        // Başlangıçta görünmez
        Color c = mesaj.color;
        c.a = 0f;
        mesaj.color = c;
    }

    void Update()
    {
        float targetAlpha = goster ? 1f : 0f;
        alpha = Mathf.MoveTowards(alpha, targetAlpha, fadeSpeed * Time.deltaTime);

        Color c = mesaj.color;
        c.a = alpha;
        mesaj.color = c;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            Envanter env = other.GetComponent<Envanter>();

            // 🔥 Anahtar yoksa mesaj göster
            if (env != null && !env.EsyaVarMi("Anahtar"))
            {
                mesaj.text = mesajMetni;
                goster = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            goster = false;
        }
    }
}