using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoTiempo;
    public void ActualizarTextoPuntos(string nuevoTexto)
    {
        textoTiempo.text = "Tiempo: " + nuevoTexto;
    }

}
