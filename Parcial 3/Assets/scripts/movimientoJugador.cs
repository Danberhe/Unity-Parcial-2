using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    public float velMov = 2f;
    public float gravedad = -9.8f;
    public float salto = 2f;

    public CharacterController controlador;

    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;

    bool enPiso;

    Vector3 velocidad;



    // Update is called once per frame
    void Update()
    {
        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);


        if(enPiso && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;

        controlador.Move(movimiento * velMov * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && enPiso)
        {
            velocidad.y = Mathf.Sqrt(salto*-2*gravedad);

        }

        //gravedad en el objeto

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad*Time.deltaTime);

    }
}
