using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class KeyFinal : MonoBehaviour
{
    public GameObject objetoLlave; 
    public GameObject[] ColliderPuerta;
    public AudioClip sonidoLlave; 
    private AudioSource audioSource; 
    private bool llaveRecogida = false; 

    void Start()
    {
        
        if (objetoLlave != null)
        {
            objetoLlave.SetActive(false);
        }

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !llaveRecogida)
        {
            llaveRecogida = true; 
            
            for (int i = 0; i < ColliderPuerta.Length; i++)
            {
                if (ColliderPuerta[i] != null)
                {
                    ColliderPuerta[i].SetActive(true);
                }
            }

            
            if (sonidoLlave != null)
            {
                audioSource.PlayOneShot(sonidoLlave);
            }

            
            if (objetoLlave != null)
            {
                Destroy(objetoLlave); 
                Debug.Log("Llave recogida y puertas activadas.");
            }
        }
    }
}


