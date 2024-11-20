using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarEstatua : MonoBehaviour
{
    public Transform simbolo; 
    public Transform estatua; 
    public float anguloPermitido = 5f; 
    public PuzzleManager puzzleManager; 

    public GameObject teclaUI; 
    private bool interactuar = false;
    private bool estatuaAlineada = false;

    void Start()
    {
        
        if (teclaUI != null)
        {
            teclaUI.SetActive(false);
        }
    }

    void Update()
    {
       
        if (interactuar && Input.GetKeyDown(KeyCode.E))
        {
            estatua.Rotate(0, 90, 0);
            VerificarDireccion();
        }
    }

    private void VerificarDireccion()
    {
        if (estatuaAlineada) return;

       
        Vector3 direccionEstatua = estatua.forward;
        Vector3 direccionSimbolo = (simbolo.position - estatua.position).normalized;

        float angulo = Vector3.Angle(direccionEstatua, direccionSimbolo);

        if (angulo < anguloPermitido)
        {
            estatuaAlineada = true;
            puzzleManager.EstatuaCorrecta(); 
            Debug.Log("Estatua alineada con el símbolo.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactuar = true;

            
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

            
            if (teclaUI != null)
            {
                teclaUI.SetActive(false);
            }
        }
    }
}
