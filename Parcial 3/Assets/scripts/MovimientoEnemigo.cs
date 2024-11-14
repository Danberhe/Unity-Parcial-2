using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent; 
    public Animator anim;

    public float rango;
    public bool atacando;
    private bool persiguiendo = false;
    
    //para atacar(quitar vida)
    public float salud = 150f;
    public int damageGolpe;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.enabled = false; // Desactivamos el NavMeshAgent al inicio
    }

    void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            if(salud < 0){
                salud = 0;
            }
        }
        if (persiguiendo)
        {
            PerseguirJugador();
        }
    }

    private void PerseguirJugador()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > rango){
            
            agent.destination = player.position;
            anim.SetBool("Walk", true);
            anim.SetBool("atacar", false); 
            atacando = false;
        }else{
            Debug.Log("ENTRO A UNA DISTANCIA MENOR");
            agent.isStopped = true; // Pausar el movimiento
            anim.SetBool("atacar", true);
            //atacando = true;
            agent.destination = transform.position;
            StartCoroutine(waitAnim());
            
            
            
            
        
            

        }
    }

    private IEnumerator waitAnim()
    {
        
        yield return new WaitForSeconds(2.12f);
        atacando = true;
        agent.isStopped = false; // Reanudar el movimiento
        //agent.speed = 0;
        
        
        
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

    public void Muerte(){
        Debug.Log("Zombie ha Muerto");
        anim.SetBool("Muerte", true);

        agent.isStopped = true;
    }


    // Método para detectar cuando el jugador entra al rango del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            persiguiendo = true;
            agent.enabled = true; // Activamos el NavMeshAgent para que persiga
        }

        if (other.CompareTag("Player") && atacando)
        {
            other.GetComponent<MovPersonaje>().getDamageP(damageGolpe);
        }

    }
    
}