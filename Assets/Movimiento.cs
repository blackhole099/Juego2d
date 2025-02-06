using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public bool mirandoDerecha = true;
    public float velocidad;
    public float fuerzaSalto;
   [SerializeField] private int saltosExtra;
   [SerializeField] private int saltosExtraRestantes;
    private Rigidbody2D rb2;
    private BoxCollider2D bc;
    private Animator animator;
    private bool salto = false;
    private bool estaSuelo = false;
    public Vector2 rango = new Vector2(1.0f, 0.5f);
    public Vector2 rango2 = new Vector2(0.5f, 1.0f);
    public LayerMask enemigo;
    [SerializeField] private Transform contSuelo;
    [SerializeField] private Vector3 dimCaja;
   

 

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        saltosExtraRestantes = saltosExtra; 
    }
    void FixedUpdate()
    {
        if (salto)
        {
            actualizarSalto();
        }
    }
    private void actualizarSalto()
    {
        if (salto)
        {
            if (estaSuelo)
            {
                Salto();
            }
            else if (saltosExtraRestantes > 0)
            {
                Salto();
                saltosExtraRestantes--;
            }
            salto = false;
        }
    }
    void Update()
    {
        procesarMovimiento();
        if (Input.GetButtonDown("Jump") && (estaSuelo || saltosExtraRestantes > 0))
        {
            salto = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Atacar();
        }
    }

  



    private void Salto()
    {
        rb2.velocity = new Vector2(rb2.velocity.x, fuerzaSalto);
    }
    void procesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        rb2.velocity = new Vector2(inputMovimiento * velocidad, rb2.velocity.y);
        gestionarMovimieto(inputMovimiento);
    }

    void gestionarMovimieto(float inputMovimiento)
    {
        if ((mirandoDerecha && inputMovimiento > 0) || (!mirandoDerecha && inputMovimiento < 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void Atacar()
    {
        animator.SetTrigger("Atacar");
        Vector2 posicion = (Vector2)transform.position + rango2 * (mirandoDerecha ? rango2 : new Vector2(-rango2.x, rango2.y));
        Collider2D[] golpear = Physics2D.OverlapBoxAll(posicion, rango, 0, enemigo);
        foreach (Collider2D enemigos in golpear)
        {
            Debug.Log("golpeado");
            enemigos.GetComponent<Enemigo>().recibirDaño(1);
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 posicion2 = (Vector2)contSuelo.position;
        Gizmos.DrawWireCube(posicion2, dimCaja);
    }
}


