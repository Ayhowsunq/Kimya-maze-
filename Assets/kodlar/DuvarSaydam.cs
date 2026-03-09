using UnityEngine;

public class DuvarSaydam : MonoBehaviour
{
    public Material normalMat;
    public Material saydamMat;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = normalMat;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            rend.material = saydamMat;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Oyuncu"))
        {
            rend.material = normalMat;
        }
    }
}