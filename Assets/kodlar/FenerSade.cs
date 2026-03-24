using UnityEngine;

public class FenerSade : MonoBehaviour
{
    public Light fenerIsik;
    public bool feneracikmi;

    void Start()
    {
        fenerIsik.enabled = false; // Başlangıçta kapalı
        feneracikmi = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fenerIsik.enabled = !fenerIsik.enabled; // Aç/kapa
            feneracikmi = !feneracikmi;
        }
    }
}