using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform personaje;
    private float tamanioCamara;
    private float alturaPantalla;
    // Start is called before the first frame update
    void Start()
    {
        tamanioCamara = Camera.main.orthographicSize;
        alturaPantalla = tamanioCamara * 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        calcularPosicionCamara();
    }
    void calcularPosicionCamara()
    {
        int pantallapersonaje =(int) (personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallapersonaje * alturaPantalla) + tamanioCamara;
        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}
