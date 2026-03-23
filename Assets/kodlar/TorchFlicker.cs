using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    public Light torchLight;      // Torch objesinin Light componenti
    public float minIntensity = 0.7f;
    public float maxIntensity = 1.2f;
    public float speed = 0.5f;    // Işığın artma/azalma hızı

    private bool increasing = false;

    void Update()
    {
        if (torchLight != null)
        {
            if (increasing)
            {
                torchLight.intensity += speed * Time.deltaTime;
                if (torchLight.intensity >= maxIntensity)
                    increasing = false;
            }
            else
            {
                torchLight.intensity -= speed * Time.deltaTime;
                if (torchLight.intensity <= minIntensity)
                    increasing = true;
            }
        }
    }
}