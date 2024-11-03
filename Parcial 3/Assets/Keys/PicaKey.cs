using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaKey : MonoBehaviour
{
    public GameObject objetoLlave;
    public GameObject[] ColliderPuerta;

    void OnTriggerEnter(Collider other){

        if (other.CompareTag("Player"))
        {
            // Recorre cada puerta en el arreglo ColliderPuerta, ya que una llave puede abrir varias puertas.
            for (int i = 0; i < ColliderPuerta.Length; i++)
            {
                // Activa el colider de cada puerta
                ColliderPuerta[i].SetActive(true);
            }
            // Destruye la llave
            Destroy(objetoLlave);//se supone que debe pasar a el inventario (todas las llaves recogidas)
        }
    }
}
