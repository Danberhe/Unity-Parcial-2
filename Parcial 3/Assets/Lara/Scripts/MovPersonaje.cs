using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float VeloMov = 5.0f; //Definimos la velocidad del movimiento del personaje
    public float VeloRot = 200.0f; //Definimos la velocidad de rotacion del personaje
    public float x, y;
    Vector3 velocidad;
    public float gravedad = -9.8f;


    private Animator animator;
    public float salud = 200f;
    public float TiempoMuerte = 2.0f;

    //public Rigidbody rb;

    public CharacterController controlador;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!Disparo.apuntando)  // Solo mover y rotar si no esta apuntando
        {
            transform.Rotate(0, x * Time.deltaTime * VeloRot, 0);
            transform.Translate(0, 0, y * Time.deltaTime * VeloMov);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!Disparo.apuntando)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            animator.SetFloat("velX", x);
            animator.SetFloat("velY", y);

            Vector3 movimiento = transform.forward * y;
            controlador.Move(movimiento * VeloMov * Time.deltaTime);

            velocidad.y += gravedad * Time.deltaTime;
            controlador.Move(velocidad*Time.deltaTime);
        }
    }

    public void getDamageP(int dmg)
    {
        salud -= dmg;
        salud = Mathf.Max(salud, 0); // Asegura que la salud no sea negativa
        Debug.Log("Zombie quitó : " + dmg + " de vida." + salud + "/ 200");
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

        StartCoroutine(waitAnim());
    }

    private IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(TiempoMuerte);

        Destroy(gameObject);
    }
}

