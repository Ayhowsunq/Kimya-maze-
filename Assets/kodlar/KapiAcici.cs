using UnityEngine;

public class KapiAcici : MonoBehaviour
{
    public Transform kapi;
    public float yukariMesafe = 4f;
    public float hiz = 2f;

    private Vector3 hedef;
    private bool acildi = false;

    void Start()
    {
        hedef = kapi.position + Vector3.up * yukariMesafe;
    }

    void Update()
    {
        if (acildi)
        {
            kapi.position = Vector3.MoveTowards(
                kapi.position,
                hedef,
                hiz * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            Envanter env = other.GetComponent<Envanter>();

            if (env != null && env.EsyaVarMi("Anahtar"))
            {
                acildi = true;
                Debug.Log("Kapı açılıyor");
            }
        }
    }
}