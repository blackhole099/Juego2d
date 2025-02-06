using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public GameManager gamemanager;
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = gamemanager.PuntosTotales.ToString();  
    }
    public void actualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }
    public void desactivarVidas(int indice)
    {
        vidas[indice].SetActive(false);
    }
    public void activarVidas(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
