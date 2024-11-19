using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class KeyFinal : MonoBehaviour
{
    public GameObject objetoLlave; // Llave física en el mundo
    public GameObject[] ColliderPuerta; // Puertas que se activarán
    private bool llaveRecogida = false; // Para evitar múltiples activaciones

    void Start()
    {
        // Asegúrate de que la llave esté desactivada al inicio del juego
        if (objetoLlave != null)
        {
            objetoLlave.SetActive(false);
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

            // "Recoge" la llave simulando que pasa al inventario
            if (objetoLlave != null)
            {
                Destroy(objetoLlave); // Esto destruye la representación física de la llave
                Debug.Log("Llave recogida y puertas activadas.");
            }
        }
    }
}



