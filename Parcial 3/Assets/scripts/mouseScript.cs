using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float sensiMouse = 100f;

    public Transform cuerpoJugador;


    float rotaX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//bloqueamos posicion del mouse y lo desaparecemos de la pantalla


    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensiMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensiMouse * Time.deltaTime;


        //rota la camara een x, se usa el  -  para evitar lo conocido como "Inverted Axis"

        rotaX -= mouseY;
        //restriccion de rotacuon de la camara entre 90 y -90

        rotaX = Mathf.Clamp( rotaX, -90f, 90f );   //el 90 es para mirar hacia arriba hacia abajo

        //se asigna los valores resultantes en rotacion de la camara al objeto como tal

        transform.localRotation = Quaternion.Euler( rotaX, 0f, 0f ) ;




        cuerpoJugador.Rotate(Vector3.up * mouseX);



    }
}
