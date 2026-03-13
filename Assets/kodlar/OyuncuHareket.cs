using UnityEngine;
using UnityEngine.UI;

public class OyuncuHareket : MonoBehaviour
{
    public float yurumeHizi = 4f;
    public float kosmaHizi = 7f;

    public float iconHizi = .5f;

    public float donmeHizi = 10f;

    public float stamina = 5f;
    public float maxStamina = 5f;

    public float yorulduStaminaArtma = 5f;

    public float staminaAzalma = 1f;
    public float staminaDolma = 0.5f;

    bool yoruldu = false;

    public Slider staminaBar;
    public GameObject yoruldunIkon;

    bool ikonDurum = false;
    float ikonTimer = 0f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (yoruldunIkon != null)
            yoruldunIkon.SetActive(false);
    }

    void Update()
    {
        Hareket();
        StaminaKontrol();
        IkonKontrol();

        if (staminaBar != null)
            staminaBar.value = stamina;
    }

    void Hareket()
    {
        if (yoruldu)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 hareket = new Vector3(h, 0, v).normalized;

        float hiz = yurumeHizi;

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
            hiz = kosmaHizi;

        Vector3 hareketVektoru = hareket * hiz;

        rb.linearVelocity = new Vector3(hareketVektoru.x, rb.linearVelocity.y, hareketVektoru.z);

        if (hareket != Vector3.zero)
        {
            Quaternion hedefRot = Quaternion.LookRotation(hareket);
            transform.rotation = Quaternion.Slerp(transform.rotation, hedefRot, donmeHizi * Time.deltaTime);
        }
    }

    void StaminaKontrol()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !yoruldu)
        {
            stamina -= staminaAzalma * Time.deltaTime;
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && !yoruldu)
        {
            stamina += staminaDolma * Time.deltaTime;
        }
        else
        {
            stamina += yorulduStaminaArtma * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        if (stamina <= 0)
        {
            yoruldu = true;
        }

        if (stamina >= maxStamina)
        {
            yoruldu = false;
        }
    }

    void IkonKontrol()
    {
        if (!yoruldu)
        {
            if (yoruldunIkon != null)
                yoruldunIkon.SetActive(false);
            return;
        }

        ikonTimer += Time.deltaTime;

        if (ikonTimer > iconHizi)
        {
            ikonDurum = !ikonDurum;

            if (yoruldunIkon != null)
                yoruldunIkon.SetActive(ikonDurum);

            ikonTimer = 0f;
        }
    }
}