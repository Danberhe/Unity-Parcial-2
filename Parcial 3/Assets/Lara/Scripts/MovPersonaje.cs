using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovPersonaje : MonoBehaviour
{
    public Disparo disparoScript; 
    
    public float VeloMov = 5.0f; 
    public float VeloRot = 200.0f; 
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

    public float salud = 400f;
 

    public Text indSalud;


    void Start(){
        MusicaFondo.Play();
        indSalud.text = "HOLA";
    }
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        disparoScript = GetComponent<Disparo>(); 
    }

    void Update()
    {
        indSalud.text = "Salud: " + salud.ToString() + " / 500";
        //indSalud.text = "";
        
        
        
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);

        Vector3 movimiento = transform.forward * y;
        controlador.Move(movimiento * VeloMov * Time.deltaTime);

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);

        
        transform.Rotate(0, x * Time.deltaTime * VeloRot, 0);
    }

    public IEnumerator getDamageP(int dmg)
    {
        salud -= dmg;
        
        
        golpeada.Play();
        salud = Mathf.Max(salud, 0);
        
        Debug.Log("Zombie quitó : " + dmg + " de vida." + salud + "/ 200");
        indSalud.text = "Salud: " + salud.ToString() + " / 400";
        yield return new WaitForSeconds(2f);
        indSalud.text = "";
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
            StartCoroutine(itemsManager.efectPildora(this));
            //ItemsManager.Instance.StartCoroutine(efectPildora(salud));
            Destroy(collision.gameObject);

           

        }

    }







}

