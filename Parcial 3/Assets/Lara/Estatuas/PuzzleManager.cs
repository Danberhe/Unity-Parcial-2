using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleManager : MonoBehaviour
{
    public GameObject llave; 
    private int estatuasCorrectas = 0; 
    public int totalEstatuas = 4; 
    public void EstatuaCorrecta()
    {
        estatuasCorrectas++;

        if (estatuasCorrectas >= totalEstatuas)
        {
            ActivarLlave();
        }
    }

    private void ActivarLlave()
    {
        llave.SetActive(true);
        Debug.Log("¡La llave ha sido activada!");
    }
}


