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
    


    //para atacar(Animacion)
    /*[SerializeField] private Transform controlGolpe;
    [SerializeField] private float radioGolpe;*/
    
    


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
            //vida.text = salud.ToString() + "%";
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
            anim.SetBool("atacar", true);
            agent.destination = transform.position;
            agent.isStopped = true; // Pausar el movimiento
            
            StartCoroutine(waitAnim());
            atacando = true;

        }
    }

    private IEnumerator waitAnim()
    {
        Debug.Log("ESPRANDO");
        yield return new WaitForSeconds(2.12f);
        agent.isStopped = false; // Reanudar el movimiento
      
    }
    //BAJAR VIDA
    public void getDamage(int dmg)
    {
        salud -= dmg;
        Debug.Log("Rebajó" + dmg + "de vida." + dmg + "/" + salud);
    
        if (salud <= 0)
        {
            Muerte();
        }
    }


    public void Muerte(){
        Debug.Log("Has Muerto");
        anim.SetBool("Muerte", true);  
        

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
            other.GetComponent<movimientoQ>().getDamage(damageGolpe);
        }
    }





























    /*public void Ataque(){

        Collider[] enemigo = Physics.OverlapCircleAll(controlGolpe.position, radioGolpe);

        if (enemigo.CompareTag("Player"))
        {
            enemigo.transform.GetComponent<PlayerManager>().getDamage(damageGolpe);
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controlGolpe.position, radioGolpe);
    }*/





    public void Final_Anim(){

        anim.SetBool("atacar", false); 
        atacando = false;
    }

    //en el personaje debe ir el siguiente metodo

    /*void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("ataque")){

            print("Daño");
        }
    }*/


    

    // Método para detectar cuando el jugador sale del rango del enemigo

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador fuera del rango. Deteniendo persecución.");
            persiguiendo = false;
            agent.enabled = false; // Desactivamos el NavMeshAgent
            // anim.SetBool("walk", false);
        }
    }*/
    
}