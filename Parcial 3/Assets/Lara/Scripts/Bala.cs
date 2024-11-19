using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int dano = 10;  // Cantidad de dao que hace la bala

    public AudioSource disparado;

    public AudioSource efectoDisparo;


    void Start()
    {

        disparado.Play();
    }

    void Update()
    {

        Destroy(gameObject, 1.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        MovimientoEnemigo enemigo = other.GetComponent<MovimientoEnemigo>();
        if (enemigo != null)
        {
            enemigo.getDamageZ(dano);  // Aplica el damage
            Debug.Log("efectoooooooooooooooooooooooooooooooooooooooooooooooo");
            efectoDisparo.Play();

                
        }
            
           
        Destroy(gameObject, 0.3f);
        
    }
}