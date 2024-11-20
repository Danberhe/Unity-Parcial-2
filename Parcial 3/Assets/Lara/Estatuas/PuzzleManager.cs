using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleManager : MonoBehaviour
{
    public GameObject llave; // Referencia a la llave
    private int estatuasCorrectas = 0; // Número de estatuas que están correctamente alineadas
    public int totalEstatuas = 4; // Total de estatuas en el puzzle

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


