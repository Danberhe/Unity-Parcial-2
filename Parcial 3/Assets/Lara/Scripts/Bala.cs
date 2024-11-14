using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int dano = 10;  // Cantidad de dao que hace la bala

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la bala colisiona con el enemigo
        if (other.CompareTag("Enemy"))
        {
            // Busca el script del enemigo y llama a la funcin getDamage
            MovimientoEnemigo enemigo = other.GetComponent<MovimientoEnemigo>();
            if (enemigo != null)
            {
                enemigo.getDamageZ(dano);  // Aplica el dano al enemigo
            }

            // Destruye la bala despus de colisionar
            Destroy(gameObject);
        }
    }
}