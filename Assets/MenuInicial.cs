using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEditor.VersionControl;

public class MenuInicial : MonoBehaviour
{
   
 public void Jugar()
    {
        SceneManager.LoadScene("SeleccionNivel");
    }
    public void Salir()
    {
        Application.Quit();
    }
 
}
