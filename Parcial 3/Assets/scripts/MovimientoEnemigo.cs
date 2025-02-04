using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public Animator anim;

    public float rango;

    public AudioSource sonido;
    
    public float rangoAtacando = 8f;

    public CapsuleCollider col;
    


    
    public float salud = 150f;
    public int damageGolpe;

    float Distancia;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        sonido.Play();
        agent.enabled = false; 
    }

    void Update()
    {
        Distancia = Vector3.Distance(transform.position, player.position);

        if (gameObject.CompareTag("Player"))
        {
            if (salud < 0)
            {
                salud = 0;
            }
        }

        if (Distancia < rangoAtacando)
        {
            
            agent.enabled = true;

            PerseguirJugador();
        }

       
    }

    private void PerseguirJugador()
    {
        
        if (Distancia > rango)
        {
            agent.destination = player.position;
            anim.SetBool("Walk", true);
            anim.SetBool("atacar", false);
        }
        else
        {
            anim.SetBool("atacar", true);
            agent.destination = transform.position;
            agent.isStopped = true;
            StartCoroutine(waitAnim());
        }

    }

    private IEnumerator waitAnim()
    {

        yield return new WaitForSeconds(2.12f);
        agent.isStopped = false; 

    }

    //BAJAR VIDA
    public void getDamageZ(int dmg)
    {
        salud -= dmg;
        Debug.Log("Rebajó" + dmg + "de vida." + dmg + "/" + salud);

        if (salud <= 0)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        if (col != null)
        {
            col.enabled = false;   // Desactivar el collider
        }
        Debug.Log("Ha Muerto zombie");
        anim.SetBool("Muerte", true);

        agent.isStopped = true;

        sonido.Pause();
        this.enabled = false;
        

    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(other.GetComponent<MovPersonaje>().getDamageP(damageGolpe));
        }
    } 
}