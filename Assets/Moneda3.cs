using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda3 : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Algo ha entrado en el trigger"); // Mensaje de depuración
        if (col.CompareTag("Player"))
        {
            Debug.Log("colision con Player");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log($"colision con: {col.tag}");
        }
    }
}

