using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorImpulsor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<ControladorPelota>().Rebote();
            gameObject.SetActive(false);
        }
    }
}
