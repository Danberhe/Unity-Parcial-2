using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float VeloMov = 5.0f; //Definimos la velocidad del movimiento del personaje
    public float VeloRot = 200.0f; //Definimos la velocidad de rotacion del personaje
    private Animator animator;
    public float x, y;
    public float salud = 200f;




    public Rigidbody rb;
  

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * VeloRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * VeloMov);
    }

    // Update is called once per frame
    void Update()
    {
        if (ArmaController.apuntando == false)
        {


            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");



            animator.SetFloat("velX", x);
            animator.SetFloat("velY", y);

        }

        
    }

    public void getDamage(int dmg)
    {
        salud -= dmg;
        salud = Mathf.Max(salud, 0); // Asegura que la salud no sea negativa
        Debug.Log("Rebajó" + dmg + "de vida." + dmg + "/" + salud);


        if (salud <= 0)
        {
            Debug.Log("LILI HA MUERTO");
            Muerte();
            
        }
    }



    public void Muerte()
    {
        Debug.Log("Has Muerto");
        animator.SetBool("Muerte", true);
    }


}

