using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaFinal : MonoBehaviour
{
    public GameObject CartaPanel;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider belongs to the player
        if (other.CompareTag("Player"))
        {
            CartaPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            CartaPanel.SetActive(false);
            Time.timeScale = 1;
        }
    } 
}
