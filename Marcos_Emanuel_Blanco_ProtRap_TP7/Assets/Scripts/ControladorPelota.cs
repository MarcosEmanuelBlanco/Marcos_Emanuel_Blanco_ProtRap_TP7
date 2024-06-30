using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControladorPelota : MonoBehaviour
{
    private Rigidbody2D rb;
    private float direccionPosicionamiento;
    [SerializeField] private float factorPosicionamiento;
    [SerializeField] private float fuerzaDisparo;
    [SerializeField] private Transform limiteIzquierdo;
    [SerializeField] private Transform limiteDerecho;
    private bool movimientoActivo;
    private int incrementoVelRebote = -2;
    [SerializeField] private int limiteMinVel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movimientoActivo = true;
    }
    private void MoveBall()
    {
        direccionPosicionamiento = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(factorPosicionamiento * direccionPosicionamiento, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, limiteIzquierdo.position.x, limiteDerecho.position.x);
        transform.position = newPosition;
    }

    void Update()
    {
        MultiplicadorRebote();
        if (movimientoActivo)
        {
            MoveBall();
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < 1)
        {
            Lanzar();
        }   
    }

    void Lanzar()
    {
        rb.AddForce(Vector2.up *  fuerzaDisparo,ForceMode2D.Impulse);
        if (movimientoActivo)
        {
            movimientoActivo = false;
        }
    }

    void MultiplicadorRebote()
    {
        if(rb.velocity.magnitude < limiteMinVel)
        {
            incrementoVelRebote = -7;
        }
        else
        {
            incrementoVelRebote = -2;
        }
    }

    public void Rebote()
    {
        rb.AddForce(rb.velocity * incrementoVelRebote,ForceMode2D.Impulse);
    }
}
