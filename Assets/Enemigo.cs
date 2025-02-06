using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameManager gamemanager;
    public int vidas = 3;
    private Transform jugador;
    private bool jugEnRango = false;
    public float rangoDeteccion = 5.0f;
    public float velocidad = 2.0f;
    public int valor = 10;
    private Rigidbody2D rb;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            gamemanager.perderVida();
            
        }
    }
    public void recibirDaño(int daño)
    {
        Debug.Log(vidas);
        vidas -= daño;
        if (vidas <= 0)
        {
            Morir();
        }
    }
    private void Morir()
    {
        Destroy(gameObject);
        gamemanager.sumarPuntos(valor);

    }
    private void DetectarJugador()
    {
        float distancia = Vector2.Distance(transform.position, jugador.position);
        if (distancia <= rangoDeteccion)
        {
            jugEnRango = true;
        }
        else
        {
            jugEnRango = false;
        }
    }
    private void seguirJugador()
    {
        Debug.Log("siguiendo jugador...");
        Vector2 direccion = new Vector2(jugador.position.x - transform.position.x,0).normalized;
        Vector2 movimiento = direccion* velocidad * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimiento);
    }
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectarJugador();
        if (jugEnRango)
        {
            seguirJugador();
        }
    }
}
