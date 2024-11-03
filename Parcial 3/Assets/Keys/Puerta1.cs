using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta1 : MonoBehaviour
{
    public string nomAnimacion = "PuertaMaderaAbierta1";
    public Animator animator;
    public AudioSource door;

    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){


            animator.Play(nomAnimacion);
            door.Play();
            Destroy(gameObject);
        }
    }
}
