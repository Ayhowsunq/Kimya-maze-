using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform hedef;
    public Vector3 offset;
    public float takipHizi = 5f;

    void LateUpdate()
    {
        if (hedef == null) return;

        Vector3 hedefPozisyon = hedef.position + offset;
        transform.position = Vector3.Lerp(transform.position, hedefPozisyon, takipHizi * Time.deltaTime);
    }
}