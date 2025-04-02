using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("✅ ¡Se detectó un objeto en el Trigger!: " + other.gameObject.name);
    }
}
