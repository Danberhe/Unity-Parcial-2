using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int daño = 10;  // Cantidad de daño que hace la bala

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la bala colisiona con el enemigo
        if (other.CompareTag("Enemy"))
        {
            // Busca el script del enemigo y llama a la función getDamage
            MovimientoEnemigo enemigo = other.GetComponent<MovimientoEnemigo>();
            if (enemigo != null)
            {
                enemigo.getDamage(daño);  // Aplica el daño al enemigo
            }

            // Destruye la bala después de colisionar
            Destroy(gameObject);
        }
    }
}