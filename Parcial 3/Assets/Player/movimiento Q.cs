using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class movimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;
    public Animator anima;


    public float salud = 200f;
    
    
    void Awake()
    {
        anima = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        


        float horizontalInput = Input.GetAxis( "Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.fixedDeltaTime, 0f);

        rb.MovePosition(rb.position +  movement*Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);

        if(verticalInput > 0 || verticalInput < 0)
        {
            //anima.SetFloat("Walk", Mathf.Abs(verticalInput));
        }
        else
        {
            //anima.SetFloat("Walk", Mathf.Abs(verticalInput));
        }

    }


    //recibe daño del enemigo
    public void getDamage(int dmg)
    {
        salud -= dmg;
        salud = Mathf.Max(salud, 0); // Asegura que la salud no sea negativa
        Debug.Log("Rebajó" + dmg + "de vida." + dmg + "/" + salud);
        

        if (salud <= 0)
        {
            Debug.Log("LILI HA MUERTO");
            Muerte();
            //Destroy(gameObject, 0.5f);
        }
    }



    public void Muerte(){
        Debug.Log("Has Muerto");
        anima.SetBool("Muerte", true);  
    }
}
