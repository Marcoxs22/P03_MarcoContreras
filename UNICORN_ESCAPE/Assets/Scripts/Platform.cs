using UnityEngine;
using System;

public class Platform : MonoBehaviour
{
    public static event Action OnPlatformDestroyed;

    private void OnBecameInvisible() // Detecta cuando la plataforma sale de la pantalla
    {
        OnPlatformDestroyed?.Invoke();
        Destroy(gameObject); // O cualquier otra lógica de eliminación
    }
}
