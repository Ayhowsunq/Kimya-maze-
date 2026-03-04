using UnityEngine;

public class Kapi : MonoBehaviour
{
    public float acilmaYuksekligi = 5f;
    public float acilmaHizi = 3f;

    private bool aciliyor = false;
    private Vector3 hedefPozisyon;

    void Start()
    {
        hedefPozisyon = transform.position + Vector3.up * acilmaYuksekligi;
    }

    void Update()
    {
        if (aciliyor)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                hedefPozisyon,
                acilmaHizi * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            aciliyor = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}