using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Respuesta : MonoBehaviour
{
    public GameObject Panel; // Panel con el problema matemático
    public TMP_Text MensajeTMP; // Texto que mostrará "Correcto!" o "Incorrecto"

    public Button Respuesta1;
    public Button Respuesta2;
    public Button Respuesta3;
    public Button Respuesta4;

    public int respuestaCorrectaIndex; // Número del botón correcto (1-4)

    public MonoBehaviour movimientoPersonaje; // Asigna aquí el script de movimiento del personaje en el Inspector

    void Start()
    {
        MensajeTMP.gameObject.SetActive(false);

        if (movimientoPersonaje != null)
        {
            movimientoPersonaje.enabled = false;
        }

        Respuesta1.onClick.AddListener(() => VerificarRespuesta(1));
        Respuesta2.onClick.AddListener(() => VerificarRespuesta(2));
        Respuesta3.onClick.AddListener(() => VerificarRespuesta(3));
        Respuesta4.onClick.AddListener(() => VerificarRespuesta(4));
    }

    void VerificarRespuesta(int respuestaSeleccionada)
    {
        if (respuestaSeleccionada == respuestaCorrectaIndex)
        {
            MensajeTMP.text = "<color=green>¡Correcto!</color>";
            MostrarMensaje();
            Invoke("CerrarPanel", 1.5f);
        }
        else
        {
            MensajeTMP.text = "<color=red>¡Incorrecto!</color>";
            MostrarMensaje();
            StartCoroutine(EsconderMensajeIncorrecto());
        }
    }

    void MostrarMensaje()
    {
        MensajeTMP.gameObject.SetActive(true);
    }

    IEnumerator EsconderMensajeIncorrecto()
    {
        yield return new WaitForSecondsRealtime(2f); // Se usa "WaitForSecondsRealtime" para que funcione con Time.timeScale = 0
        MensajeTMP.gameObject.SetActive(false);
    }

void CerrarPanel()
{
    Panel.SetActive(false);
    Time.timeScale = 1f; // Reanudar el tiempo

    if (movimientoPersonaje != null)
    {
        movimientoPersonaje.enabled = true;
    }
}

}
