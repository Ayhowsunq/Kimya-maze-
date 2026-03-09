using UnityEngine;
using UnityEngine.UI;

public class OyuncuHareket : MonoBehaviour
{
    public float yurumeHizi = 4f;
    public float kosmaHizi = 7f;
    public float hizlanma = 8f;
    float mevcutHiz;

    public float donmeHizi = 10f;

    public float stamina = 5f;
    public float maxStamina = 5f;

    public float staminaAzalma = 1f;
    public float staminaDolma = 0.5f;

    bool yoruldu = false;

    public Slider staminaBar;

    CharacterController controller;

    Vector3 normalScale;
    Vector3 comelmisScale;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        normalScale = transform.localScale;
        comelmisScale = new Vector3(normalScale.x, normalScale.y * 0.5f, normalScale.z);
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 hareket = new Vector3(h, 0, v).normalized;

        float hedefHiz = yurumeHizi;

        if (!yoruldu && Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            hedefHiz = kosmaHizi;
            stamina -= staminaAzalma * Time.deltaTime;
        }
        else
        {
            if (yoruldu)
                stamina += (staminaDolma * 3f) * Time.deltaTime;
            else
                stamina += staminaDolma * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        if (stamina <= 0)
        {
            yoruldu = true;
            hareket = Vector3.zero;
            transform.localScale = comelmisScale;
        }

        if (stamina >= maxStamina)
        {
            yoruldu = false;
            transform.localScale = normalScale;
        }

        if (!yoruldu)
        {
            mevcutHiz = Mathf.Lerp(mevcutHiz, hedefHiz, hizlanma * Time.deltaTime);
            controller.Move(hareket * mevcutHiz * Time.deltaTime);
        }

        if (hareket != Vector3.zero)
        {
            Quaternion hedefRotasyon = Quaternion.LookRotation(hareket);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRotasyon, donmeHizi * Time.deltaTime);
        }

        if (staminaBar != null)
        {
            staminaBar.value = stamina;
        }
    }
}