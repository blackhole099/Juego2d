using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject panelInstrucciones;
    public void activarInstrucciones()
    {
        panelInstrucciones.SetActive(true);
    }
    public void desactivarInstrucciones()
    {
        panelInstrucciones.SetActive(false);
    }
}
