using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para trabajar con UI (o usa TMPro si prefieres)



public class KeyFinal : MonoBehaviour
{
    public GameObject objetoLlave; // Llave física en el mundo
    public GameObject[] ColliderPuerta; // Puertas que se activarán
    public AudioClip sonidoLlave; // Clip de sonido para la llave
    private AudioSource audioSource; // Fuente de audio para reproducir el sonido
    private bool llaveRecogida = false; // Para evitar múltiples activaciones

    void Start()
    {
        // Asegúrate de que la llave esté desactivada al inicio del juego
        if (objetoLlave != null)
        {
            objetoLlave.SetActive(false);
        }

        // Añadir o buscar un componente AudioSource en el objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !llaveRecogida)
        {
            llaveRecogida = true; // Marca la llave como recogida

            // Activa cada puerta en el arreglo
            for (int i = 0; i < ColliderPuerta.Length; i++)
            {
                if (ColliderPuerta[i] != null)
                {
                    ColliderPuerta[i].SetActive(true);
                }
            }

            // Reproducir sonido de la llave si el clip está asignado
            if (sonidoLlave != null)
            {
                audioSource.PlayOneShot(sonidoLlave);
            }

            // "Recoge" la llave simulando que pasa al inventario
            if (objetoLlave != null)
            {
                Destroy(objetoLlave); // Esto destruye la representación física de la llave
                Debug.Log("Llave recogida y puertas activadas.");
            }
        }
    }
}


