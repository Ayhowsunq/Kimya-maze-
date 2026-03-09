using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    Light torchLight;
    public float minIntensity = 1.8f;
    public float maxIntensity = 3f;

    void Start()
    {
        torchLight = GetComponent<Light>();
    }

    void Update()
    {
        torchLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}