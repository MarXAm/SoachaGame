using UnityEngine;
using TMPro; // Solo si usas TextMeshPro

public class Matematicas : MonoBehaviour
{
    public GameObject Panel;
    public TMP_Text Problema; // Si usas TMP_Text (TextMeshPro)
    private bool yaActivado = false; // Variable para evitar que el panel se active más de una vez

    void Start()
    {
        if (Problema == null)
        {
            Problema = GameObject.Find("Problema").GetComponent<TMP_Text>();
        }

        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !yaActivado) // Evita que el panel se abra más de una vez
        {
            Debug.Log("🚀 Jugador detectado en el Trigger, activando Panel...");

            Panel.SetActive(true); // Activar el Panel

            yaActivado = true; // Evita que se vuelva a activar
        }
    }
}
