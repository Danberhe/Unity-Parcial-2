using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class RotarEstatua : MonoBehaviour
{
    public Transform simbolo; // Referencia al símbolo en la pared
    public Transform estatua; // Referencia al objeto de la estatua
    public float anguloPermitido = 5f; // Margen de error para considerar que está mirando el símbolo
    public PuzzleManager puzzleManager; // Referencia al gestor del puzzle

    private bool interactuar = false;
    private bool estatuaAlineada = false;

    void Update()
    {
        // Si el jugador está en rango y presiona un botón
        if (interactuar && Input.GetKeyDown(KeyCode.E))
        {

            estatua.Rotate(0, 90, 0); // Rota la estatua 90 grados en Y
            VerificarDireccion();
        }
    }

    private void VerificarDireccion()
    {
        if (estatuaAlineada) return;


        Debug.Log("Verificando la dirección de la estatua...");
        // Calcula el ángulo entre la dirección de la estatua y el símbolo
        Vector3 direccionEstatua = estatua.forward;
        Vector3 direccionSimbolo = (simbolo.position - estatua.position).normalized;

        Debug.DrawLine(estatua.position, estatua.position + direccionEstatua * 5, Color.red, 2f); // Dirección de la estatua
        Debug.DrawLine(estatua.position, simbolo.position, Color.blue, 2f); // Dirección al símbolo

        float angulo = Vector3.Angle(direccionEstatua, direccionSimbolo);
        Debug.Log($"Ángulo entre la estatua y el símbolo: {angulo}");

        if (angulo < anguloPermitido)
        {
            Debug.Log("Estatua correctamente alineada.");
            estatuaAlineada = true;
            puzzleManager.EstatuaCorrecta(); // Notifica al puzzle manager que esta estatua está correcta
            Debug.Log("Estatua alineada con el símbolo.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
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


