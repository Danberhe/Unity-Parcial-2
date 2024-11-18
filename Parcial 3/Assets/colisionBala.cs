using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionBala : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la bala colisiona con el enemigo
         Debug.Log("BALA CONTACTA");
    }
}
