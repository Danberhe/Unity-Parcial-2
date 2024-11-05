using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour
{
    public static bool apuntando = false;
    public GameObject player;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            apuntando = true;
            animator.SetBool("Disparando",true);
            Debug.Log("Se la metio");
        }
        if (Input.GetMouseButtonUp(1))
        {
            apuntando = false;
            animator.SetBool("Disparando", false);

        }
    }
}
