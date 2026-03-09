using UnityEngine;

public class MesaleKontrol : MonoBehaviour
{
    public GameObject mesale;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mesale.SetActive(!mesale.activeSelf);
        }
    }
}