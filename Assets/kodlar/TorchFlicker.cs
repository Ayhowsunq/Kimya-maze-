using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    Light torchLight;

    public float minIntensity = 1.8f;
    public float maxIntensity = 3f;

    public float maxPlayerLight = 20f;
    public float minPlayerLight = 15f;
    public int lightVelocity = 5;

    float currentLight;
    bool increasing = true;

    void Start()
    {
        torchLight = GetComponent<Light>();
        currentLight = minPlayerLight;
    }

    void Update()
    {
        if (CompareTag("Mesale"))
        {
            if (increasing)
            {
                currentLight += Time.deltaTime * lightVelocity;

                if (currentLight >= maxPlayerLight)
                    increasing = false;
            }
            else
            {
                currentLight -= Time.deltaTime * lightVelocity;

                if (currentLight <= minPlayerLight)
                    increasing = true;
            }

            torchLight.intensity = currentLight;
        }
        else
        {
            torchLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}