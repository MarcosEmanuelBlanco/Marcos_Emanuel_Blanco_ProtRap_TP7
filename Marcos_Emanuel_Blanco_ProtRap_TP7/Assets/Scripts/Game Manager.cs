using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> OnTimeChange;
    [SerializeField] private UnityEvent<string> OnTotalTimeChange;
    [SerializeField] private TextMeshProUGUI textoTiempo;
    [SerializeField] private TextMeshProUGUI textoNivelCompletado;
    private bool siguienteLVL;
    [SerializeField] private GameObject llegada;
    private float tiempo = 0;
    void Start()
    {
        tiempo = 0;
        OnTimeChange.Invoke(tiempo.ToString());
        textoNivelCompletado.gameObject.SetActive(false);
        siguienteLVL = false;
    }

    void RestarTiempo()
    {
        tiempo += Time.deltaTime;
        Mathf.RoundToInt(tiempo);
        OnTimeChange.Invoke(tiempo.ToString());
    }
    void Update()
    {
        RestarTiempo();
        ReiniciarEscena();
        SiguienteNivel();
        NivelCompletado();
        CerrarApp();
    }

    void NivelCompletado()
    {
        if (!llegada.activeInHierarchy)
        {
            Time.timeScale = 0;
            textoNivelCompletado.gameObject.SetActive(true);
            siguienteLVL = true;
        }
    }
    void ReiniciarEscena()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            llegada.SetActive(true);
        }
    }

    void SiguienteNivel()
    {
        if (siguienteLVL && Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            siguienteLVL = false;
            llegada.SetActive(true);
        }
    }

    void CerrarApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
