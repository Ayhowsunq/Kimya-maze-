using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    public float hiz = 10f;
    public float donusHizi = 10f;

    private Rigidbody rb;
    private Vector3 hareket;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

        hareket = new Vector3(yatay, 0f, dikey).normalized;
    }

    void FixedUpdate()
    {
        // Hareket
        rb.linearVelocity = new Vector3(hareket.x * hiz, rb.linearVelocity.y, hareket.z * hiz);

        // Yumuşak dönüş
        if (hareket != Vector3.zero)
        {
            Quaternion hedefRotasyon = Quaternion.LookRotation(hareket);
            rb.rotation = Quaternion.Slerp(rb.rotation, hedefRotasyon, donusHizi * Time.fixedDeltaTime);
        }
    }
}