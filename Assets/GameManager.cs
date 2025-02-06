using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public TextMeshProUGUI texto;
    public Puntuacion punt;
    private int vidas = 3;
    public void sumarPuntos(int puntosSumar) {
        puntosTotales += puntosSumar;
        punt.actualizarPuntos(puntosTotales);
    }
    public void perderVida()
    {
        vidas-=1;
        punt.desactivarVidas(vidas);
        if (vidas == 0)
        {
            SceneManager.LoadScene("GameOver");  
        }
    }
    public void recuperarVida()
    {
        if (vidas < 3)
        {
            punt.activarVidas(vidas);
            vidas += 1;
        }
       
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
