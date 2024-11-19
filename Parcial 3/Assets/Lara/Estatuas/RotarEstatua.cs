using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class RotarEstatua : MonoBehaviour
{
    public Transform simbolo; // Referencia al s�mbolo en la pared
    public Transform estatua; // Referencia al objeto de la estatua
    public float anguloPermitido = 5f; // Margen de error para considerar que est� mirando el s�mbolo
    public PuzzleManager puzzleManager; // Referencia al gestor del puzzle

    private bool interactuar = false;
    private bool estatuaAlineada = false;

    void Update()
    {
        // Si el jugador est� en rango y presiona un bot�n
        if (interactuar && Input.GetKeyDown(KeyCode.E))
        {

            estatua.Rotate(0, 90, 0); // Rota la estatua 90 grados en Y
            VerificarDireccion();
        }
    }

    private void VerificarDireccion()
    {
        if (estatuaAlineada) return;


        Debug.Log("Verificando la direcci�n de la estatua...");
        // Calcula el �ngulo entre la direcci�n de la estatua y el s�mbolo
        Vector3 direccionEstatua = estatua.forward;
        Vector3 direccionSimbolo = (simbolo.position - estatua.position).normalized;

        Debug.DrawLine(estatua.position, estatua.position + direccionEstatua * 5, Color.red, 2f); // Direcci�n de la estatua
        Debug.DrawLine(estatua.position, simbolo.position, Color.blue, 2f); // Direcci�n al s�mbolo

        float angulo = Vector3.Angle(direccionEstatua, direccionSimbolo);
        Debug.Log($"�ngulo entre la estatua y el s�mbolo: {angulo}");

        if (angulo < anguloPermitido)
        {
            Debug.Log("Estatua correctamente alineada.");
            estatuaAlineada = true;
            puzzleManager.EstatuaCorrecta(); // Notifica al puzzle manager que esta estatua est� correcta
            Debug.Log("Estatua alineada con el s�mbolo.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga el tag "Player"
        {
            interactuar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactuar = false;
        }
    }
}


