using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovPersonaje : MonoBehaviour
{
    public Disparo disparoScript; 
    
    public float VeloMov = 5.0f; // Velocidad del movimiento del personaje
    public float VeloRot = 200.0f; // Velocidad de rotación del personaje
    public float x, y;
    Vector3 velocidad;
    public float gravedad = -9.8f;

    private Animator animator;
    
    public float TiempoMuerte = 2.0f;

    public AudioSource MusicaFondo;
    public AudioSource golpeada;

    public CharacterController controlador;

    //items
    public ItemsManager itemsManager;

    public float salud = 200f;
 

    public Text indSalud;


    void Start(){
        MusicaFondo.Play();
    }
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        disparoScript = GetComponent<Disparo>(); // es pa obtener el componente disparo
    }

    void Update()
    {
        indSalud.text = "Salud: " + salud.ToString() + " / 500";
        
        
        // Movimiento y rotación del personaje según las entradas del jugador
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);

        Vector3 movimiento = transform.forward * y;
        controlador.Move(movimiento * VeloMov * Time.deltaTime);

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);

        // Rotación del personaje
        transform.Rotate(0, x * Time.deltaTime * VeloRot, 0);
    }

    public void getDamageP(int dmg)
    {
        salud -= dmg;
        golpeada.Play();
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
        this.enabled = false;
        disparoScript.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "pildora")
        {
            Debug.Log("entro a pildoras");
            StartCoroutine(itemsManager.efectPildora(ref salud));
            //ItemsManager.Instance.StartCoroutine(efectPildora(salud));
            Destroy(collision.gameObject);

           

        }

    }







}

