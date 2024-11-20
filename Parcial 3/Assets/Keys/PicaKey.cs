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
            //un arreglo, ya que una llave puede abrir varias puertas.
            for (int i = 0; i < ColliderPuerta.Length; i++)
            {
                // Activa el colider de cada puerta
                ColliderPuerta[i].SetActive(true);
            }
            
            Destroy(objetoLlave);
        }
    }
}
