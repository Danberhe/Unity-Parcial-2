using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEstatua : MonoBehaviour
{
    public Transform simbolo; // Referencia al s�mbolo en la pared
    public Transform estatua; // Referencia al objeto de la estatua
    public float anguloPermitido = 5f; // Margen de error para considerar que est� mirando el s�mbolo
    public PuzzleManager puzzleManager; // Referencia al gestor del puzzle

    public GameObject teclaUI; // Referencia al UI de la tecla (imagen)

    private bool interactuar = false;
    private bool estatuaAlineada = false;

    void Start()
    {
        // Aseg�rate de que el UI est� desactivado al inicio
        if (teclaUI != null)
        {
            teclaUI.SetActive(false);
        }
    }

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

        // Calcula el �ngulo entre la direcci�n de la estatua y el s�mbolo
        Vector3 direccionEstatua = estatua.forward;
        Vector3 direccionSimbolo = (simbolo.position - estatua.position).normalized;

        float angulo = Vector3.Angle(direccionEstatua, direccionSimbolo);

        if (angulo < anguloPermitido)
        {
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

            // Muestra el UI de la tecla
            if (teclaUI != null)
            {
                teclaUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactuar = false;

            // Oculta el UI de la tecla
            if (teclaUI != null)
            {
                teclaUI.SetActive(false);
            }
        }
    }
}
