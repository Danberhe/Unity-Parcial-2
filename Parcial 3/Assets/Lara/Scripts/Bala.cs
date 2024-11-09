using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int da�o = 10;  // Cantidad de da�o que hace la bala

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la bala colisiona con el enemigo
        if (other.CompareTag("Enemy"))
        {
            // Busca el script del enemigo y llama a la funci�n getDamage
            MovimientoEnemigo enemigo = other.GetComponent<MovimientoEnemigo>();
            if (enemigo != null)
            {
                enemigo.getDamage(da�o);  // Aplica el da�o al enemigo
            }

            // Destruye la bala despu�s de colisionar
            Destroy(gameObject);
        }
    }
}