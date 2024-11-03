using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float VeloMov = 5.0f; //Definimos la velocidad del movimiento del personaje
    public float VeloRot = 200.0f; //Definimos la velocidad de rotacion del personaje
    private Animator animator;
    public float x, y;

    public bool TieneArma = false;

    public Rigidbody rb;
  

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        TieneArma = true;
    }


    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * VeloRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * VeloMov);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);

        
    }
    
}

