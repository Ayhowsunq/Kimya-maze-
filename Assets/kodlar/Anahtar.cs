using UnityEngine;

public class Anahtar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            Envanter env = other.GetComponent<Envanter>();
            if (env != null)
            {
                env.EsyaEkle("Anahtar");
                Destroy(gameObject);
            }
        }
    }
}