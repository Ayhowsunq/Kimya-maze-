using System.Collections.Generic;
using UnityEngine;

public class Envanter : MonoBehaviour
{
    private List<string> esyalar = new List<string>();

    public void EsyaEkle(string ad)
    {
        esyalar.Add(ad);
        Debug.Log("Eklendi: " + ad);
    }

    public bool EsyaVarMi(string ad)
    {
        return esyalar.Contains(ad);
    }
}