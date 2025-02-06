using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    Rigidbody2D rb2;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento(); 
    }
    void movimiento()
    {
        rb2 = GetComponent<Rigidbody2D>();
        float movimiento = Input.GetAxis("Horizontal");
        rb2.velocity = new Vector2(movimiento * velocidad, rb2.velocity.y);
    }
}
