using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda2 : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Algo ha entrado en el trigger"); // Mensaje de depuración
        if (col.CompareTag("Player"))
        {
            gameManager.sumarPuntos(valor);
            Debug.Log("colision con Player");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log($"colision con: {col.tag}");
        }
    }
}
